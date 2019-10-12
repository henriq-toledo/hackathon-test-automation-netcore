using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;

namespace HackathonTestAutomationNetCore.Tests.Interfaces
{
    internal interface ISetter<TType, TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        TFormHelper SetValue(TType value);
    }
}
