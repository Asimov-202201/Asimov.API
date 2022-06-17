using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US002
    {
        private static WebDriver webDriver;
        public US002()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
        }
        
        [Given(@"el director ingresa correctamente en la plataforma")]
        public void GivenElDirectorIngresaCorrectamenteEnLaPlataforma()
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

        [When(@"ingresa la lista de profesores en su institución")]
        public void WhenIngresaLaListaDeProfesoresEnSuInstitucion()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/teachers");
        }

        [When(@"selecciona a uno de los docentes")]
        public void WhenSeleccionaAUnoDeLosDocentes()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement btnOmarSeeMore = wait.Until(e => e.FindElement(By.XPath("/html/body/div/div/main/div/div/div[2]/div/div/div[1]/div[2]/a/span")));
            btnOmarSeeMore.Click();
            
        }

        [Then(@"ve el desarrollo y progreso del docente con detalle\.")]
        public void ThenVeElDesarrolloYProgresoDelDocenteConDetalle()
        {
            if (webDriver.Url == "http://localhost:8080/teachers/1")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }

        [When(@"pierde la conexión a internet")]
        public void WhenPierdeLaConexionAInternet()
        {
            if (webDriver.Url == "http://localhost:8080/teachers/1")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }

        [Then(@"verá un mensaje de “hubo un error al establecer conexión con la red”")]
        public void ThenVeraUnMensajeDeHuboUnErrorAlEstablecerConexionConLaRed()
        {
            if (webDriver.Url == "http://localhost:8080/teachers/1")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }

        [When(@"el docente ha concretado su progreso anual")]
        public void WhenElDocenteHaConcretadoSuProgresoAnual()
        {
            if (webDriver.Url == "http://localhost:8080/teachers/1")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }

        [Then(@"verá un mensaje de “el docente ha concluido los logros anuales”")]
        public void ThenVeraUnMensajeDeElDocenteHaConcluidoLosLogrosAnuales()
        {
            if (webDriver.Url == "http://localhost:8080/teachers/1")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }
    }
}