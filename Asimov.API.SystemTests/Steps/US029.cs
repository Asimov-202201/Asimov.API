using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US029
    {
        private static WebDriver webDriver;
        public US029()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
        }
        
        [Given(@"el docente se encuentra en un curso")]
        public void GivenElDocenteSeEncuentraEnUnCurso()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/sign-up");
            var btnGoLogin =
                webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div[2]/div/a/span"));
            btnGoLogin.Click();
            var tbxEmail = webDriver.FindElement(By.Id("input-76"));
            tbxEmail.SendKeys("omar@gmail.com");

            var tbxPassword = webDriver.FindElement(By.Id("input-81"));
            tbxPassword.SendKeys("alves");

            var radiousTeacher = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[2]/form/div[3]/div[1]/div[1]/div/div[2]/div/div"));
            radiousTeacher.Click();

            webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[3]/button[2]/span")).Click(); 
            
            var waitSideMenu = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            var sideMenuTeacher = waitSideMenu.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/header/div/button[1]/span/i")));
            sideMenuTeacher.Click();

            webDriver.Navigate().GoToUrl("http://localhost:8080/courses");
                
            var waitIngresarCurso = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            var ingresarCurso = waitIngresarCurso.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div[2]/div/div/div[1]/div[3]/a")));
            ingresarCurso.Click();
        }

        [When(@"le da click al botón completar de un ítem")]
        public void WhenLeDaClickAlBotonCompletarDeUnItem()
        {
            var waitBtnItemVideo = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItem = waitBtnItemVideo.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div/div[2]/div[1]/div[1]/div/div/div[2]/button")));
            btnItem.Click();
            
            var waitBtnItemComplete = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemComplete = waitBtnItemComplete.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[3]/div/div/div[3]/button[2]")));
            btnItemComplete.Click();
        }

        [Then(@"el ítem se completará y el progreso de un curso aumenta")]
        public void ThenElItemSeCompletaraYElProgresoDeUnCursoAumenta()
        {
        }

        [When(@"no le da click al botón completar de un ítem")]
        public void WhenNoLeDaClickAlBotonCompletarDeUnItem()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement btnItem = wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div/div[2]/div[1]/div[2]/div/div/div[2]/button/span")));
            btnItem.Click();
            
            var waitBtnCancel = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnCancel = waitBtnCancel.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/button[1]/span")));
            btnCancel.Click();

        }

        [Then(@"el ítem quedará incompleto y el progreso del curso no aumentará")]
        public void ThenElItemQuedaraIncompletoYElProgresoDelCursoNoAumentara()
        {
        }

        [When(@"el docente haya abierto un ítem")]
        public void WhenElDocenteHayaAbiertoUnItem()
        {
            var waitBtnItemVideo = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItem = waitBtnItemVideo.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div/div[2]/div[1]/div[3]/div/div/div[2]/button/span")));
            btnItem.Click();
            
        }

        [When(@"olvide dar click al botón completar de un ítem")]
        public void WhenOlvideDarClickAlBotonCompletarDeUnItem()
        {
            var waitBtnCancel = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnCancel = waitBtnCancel.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[3]/div/div/div[3]/button[1]/span")));
            btnCancel.Click();
        }

        [Then(@"se le enviará una notificación preguntando si completo el ítem\.")]
        public void ThenSeLeEnviaraUnaNotificacionPreguntandoSiCompletoElItem()
        {
        }
    }
}