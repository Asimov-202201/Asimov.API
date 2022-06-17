using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US013
    {
        private static WebDriver webDriver;
        public US013()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));        }
        
        [Given(@"el director ingresa correctamente a su cuenta")]
        public void GivenElDirectorIngresaCorrectamenteASuCuenta()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/sign-up");
            var btnGoToLogin = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div[2]/div/a/span"));
            btnGoToLogin.Click();

            var tboxEmail = webDriver.FindElement(By.XPath("//*[@id='input-76']"));
            tboxEmail.SendKeys("julio@gmail.com");
            
            var tboxPassword = webDriver.FindElement(By.XPath("//*[@id='input-81']"));
            tboxPassword.SendKeys("yulius15");
            
            var radiusDirector = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[2]/form/div[3]/div[1]/div[1]/div/div[1]/div/div"));
            radiusDirector.Click();
            
            var btnSubmit = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[3]/button[2]/span"));
            btnSubmit.Click();
            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement btnProfile = wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div/header/div/a/span")));
            btnProfile.Click();
            webDriver.Navigate().GoToUrl("http://localhost:8080/dashboard");
        }
        
        [When(@"selecciona la opción “Top Teachers” de la barra izquierda")]
        public void WhenSeleccionaLaOpcionTopTeachersDeLaBarraIzquierda()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/top-teachers");
        }

        [Then(@"aparece el mensaje “Tabla de posiciones no disponible”")]
        public void ThenApareceElMensajeTablaDePosicionesNoDisponible()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/top-teachers");
            if (webDriver.Url == "http://localhost:8080/top-teachers")
            {
                Console.Write("On top teachers");
            }
        }

        [Then(@"visualiza la tabla de posiciones de los docentes")]
        public void ThenVisualizaLaTablaDePosicionesDeLosDocentes()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/top-teachers");
            if (webDriver.Url == "http://localhost:8080/top-teachers")
            {
                Console.Write("On top teachers");
            }
        }
    }
}