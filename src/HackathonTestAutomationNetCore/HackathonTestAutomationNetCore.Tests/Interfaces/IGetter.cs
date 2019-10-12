using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;

namespace HackathonTestAutomationNetCore.Tests.Interfaces
{
    internal interface IGetter<TType, TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        TFormHelper GetValue(out TType value);
    }
}
