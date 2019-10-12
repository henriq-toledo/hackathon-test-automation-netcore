using HackathonTestAutomationNetCore.Common.Classes.Attributes;
using HackathonTestAutomationNetCore.Common.Enums;
using HackathonTestAutomationNetCore.Tests.Classes.Helpers.Forms;
using NUnit.Framework;

namespace HackathonTestAutomationNetCore.Tests.Classes.Tests
{
    [TestFixture]
    public class ConnectCommunityTest : BaseTest
    {
        [Test]
        [Defect(PriorityEnum.High, SeverityEnum.Critical, description: "The required fields if blank should have an error message when click in connect and apply.")]
        public void RequiredFieldsShouldHaveAnErrorMessageWhenNotFilled()
        {
            //Arrange            
            var expectedMessage = "Esse campo é obrigatório.";
            
            //Act
            ConnectCommunityFormHelper.Open(jobId: "248472BR-PT")
                .ConnectAndApply.Click()
                .FirstName.GetError(out var firstNameErrorMessage)
                .LastName.GetError(out var lastNameErrorMessage)
                .PrimaryEmail.GetError(out var primaryEmailErrorMessage);
            
            //Assert
            Assert.AreEqual(expected: expectedMessage, actual: firstNameErrorMessage,
                message: "The Name required field should have an error message when not filed");

            Assert.AreEqual(expected: expectedMessage, actual: lastNameErrorMessage,
                message: "The Last Name required field should have an error message when not filed");

            Assert.AreEqual(expected: expectedMessage, actual: primaryEmailErrorMessage,
                message: "The Primary e-mail required field should have an error message when not filed");
        }
    }
}
