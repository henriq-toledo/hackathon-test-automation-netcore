using HackathonTestAutomationNetCore.Tests.Classes.Entities;
using HackathonTestAutomationNetCore.Tests.Classes.Extensions;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using HackathonTestAutomationNetCore.Tests.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackathonTestAutomationNetCore.Tests.Classes.Controls
{
    internal class GridControl<TEntity, TFormHelper> : BaseControl<TFormHelper>, IGetter<TEntity[], TFormHelper>
        where TFormHelper : BaseFormHelper
        where TEntity : BaseEntity, new()
    {
        private Type _type;
        private Dictionary<string, string> _propertiesDescriptionValues;

        protected Dictionary<byte, string> Columns { get; set; }
        protected List<TEntity> Rows { get; set; }

        protected GridControl(By findBy, TFormHelper formHelper) : base(findBy, formHelper)
        {
            _type = typeof(TEntity);
            _propertiesDescriptionValues = _type.GetPropertiesDescriptionValues();
        }

        public static GridControl<TEntity, TFormHelper> CreateByXPath(string xPath, TFormHelper formHelper)
        {
            var gridControl = new GridControl<TEntity, TFormHelper>(By.XPath(xPath), formHelper);

            return gridControl;
        }

        public TFormHelper GetValue(out TEntity[] rows)
        {
            this.Load();

            rows = this.Rows.ToArray();

            return this.FormHelper;
        }

        private void LoadColumns()
        {
            Columns = new Dictionary<byte, string>();
            byte count = 0;

            this.WebElement.FindElements(By.TagName("th"))
                .Select(e => e.FindElement(By.TagName("a")))
                .ToList()
                .ForEach(a =>
                {
                    Columns.Add(count, a.Text);
                    count++;
                });
        }

        private void LoadLines()
        {           
            var body = this.WebElement.FindElement(By.TagName("tbody"));

            foreach (var tableRows in body.FindElements(By.TagName("tr")))
            {
                var tableData = tableRows.FindElements(By.TagName("td"));
                var row = new TEntity[tableData.Count];
                byte count = 0;

                var entity = TypeHelper.Instantiate<TEntity>();

                foreach (var tableRow in tableData)
                {
                    count = (byte)tableData.IndexOf(tableRow);

                    var column = this.GetColumn(count);

                    if (string.IsNullOrEmpty(column))
                    {
                        continue;
                    }

                    var text = tableRow.Text;
                    var link = this.GetLink(tableRow);

                    if (link == null == false)
                    {
                        text = link.Text;
                        entity.SetLink(link.GetAttribute("href"));
                    }

                    this.SetProperty(entity, column, text);
                }

                this.Rows.Add(entity);
            }
        }

        private string GetColumn(byte index)
        {
            var column = string.Empty;

            this.Columns.TryGetValue(index, out column);

            return column;
        }

        private string GetPropertyNameByColumnName(string column)
        {
            return _propertiesDescriptionValues.FirstOrDefault(c => c.Value == column).Key;
        }

        private void SetProperty(TEntity entity, string column, string value)
        {
            var propertyName = this.GetPropertyNameByColumnName(column);

            _type.GetProperty(propertyName).SetValue(entity, value);
        }

        private IWebElement GetLink(IWebElement webElement)
        {
            IWebElement link;

            try
            {
                link = webElement.FindElement(By.TagName("a"));
            }
            catch (NoSuchElementException)
            {
                link = null;
            }

            return link;
        }

        private void Load()
        {
            this.Rows = new List<TEntity>();

            if (this.IsElementPresent)
            {
                this.LoadColumns();
                this.LoadLines();
            }
        }
    }
}