using System;
using TechTalk.SpecFlow;
using NUnit.Framework;


namespace SpecFlow.Specs
{
    [Binding]
    public class EncryptionSteps
    {
        string password;
        Security.UserPasswordHashed hashedPass;
        bool isMatch;
        [Given(@"I provided password")]
        public void GivenIProvidedPassword()
        {
                password = "test123";
        }

                [When(@"I call CreateHashedPassword method")]
        public void WhenICallCreateHashedPasswordMethod()
        {
            hashedPass = Security.ValidationHelper.GetHashedCredentials(password);
        }

                [Then(@"I want to see hash and salt for it")]
        public void ThenIWantToSeeHashAndSaltForIt()
        {
            Assert.IsNotNull(hashedPass);
        }

        [Given(@"I have created password")]
        public void GivenIHaveCreatedPassword()
        {
            password = "test123";
            hashedPass = Security.ValidationHelper.GetHashedCredentials(password);
            
        }

        [When(@"I call Validate method with right password")]
        public void WhenICallValidateMethodWithRightPassword()
        {
            isMatch = Security.ValidationHelper.ValidatePassword("test123", hashedPass);
        }

        [Then(@"I want to see that passwords match")]
        public void ThenIWantToSeeThatPasswordsMatch()
        {
            Assert.AreEqual(isMatch, true);
        }

        [When(@"I call Validate method with wrong password")]
        public void WhenICallValidateMethodWithWrongPassword()
        {
            isMatch = Security.ValidationHelper.ValidatePassword("666", hashedPass);
        }

        [Then(@"I want to see that passwords do not match")]
        public void ThenIWantToSeeThatPasswordsDoNotMatch()
        {
            Assert.AreEqual(isMatch, false);
        }

    }

}
