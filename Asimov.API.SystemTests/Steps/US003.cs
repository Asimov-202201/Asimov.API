using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US003
    {
        private static WebDriver webDriver;
        public US003()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
        }
        [Given(@"el docente ingresa correctamente en la plataforma")]
        public void GivenElDocenteIngresaCorrectamenteEnLaPlataforma()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/sign-up");
            var btnGoToLogin = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div[2]/div/a/span"));
            btnGoToLogin.Click();

            var tboxEmail = webDriver.FindElement(By.XPath("//*[@id='input-76']"));
            tboxEmail.SendKeys("omar@gmail.com");
            
            var tboxPassword = webDriver.FindElement(By.XPath("//*[@id='input-81']"));
            tboxPassword.SendKeys("alves");
            
            var radiusTeacher = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div/div[2]/form/div[3]/div[1]/div[1]/div/div[2]/div/div"));
            radiusTeacher.Click();
            
            var btnSubmit = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[3]/button[2]/span"));
            btnSubmit.Click();
            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement btnProfile = wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div/header/div/a/span")));
            btnProfile.Click();
            webDriver.Navigate().GoToUrl("http://localhost:8080/dashboard");
            
        }

        [When(@"está en el menú principal")]
        public void WhenEstaEnElMenuPrincipal()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/dashboard");
        }

        [Then(@"visualizará un resumen de su progreso en el año escolar hasta la actualidad")]
        public void ThenVisualizaraUnResumenDeSuProgresoEnElAnoEscolarHastaLaActualidad()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }

        [When(@"pierde conexión a internet")]
        public void WhenPierdeConexionAInternet()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }

        [Then(@"un mensaje aconseja volver a cargar la página")]
        public void ThenUnMensajeAconsejaVolverACargarLaPagina()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }

        [When(@"ha concluido las metas del año")]
        public void WhenHaConcluidoLasMetasDelAno()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }

        [Then(@"observará un mensaje de felicitaciones por el cumplimientos de las metas")]
        public void ThenObservaraUnMensajeDeFelicitacionesPorElCumplimientosDeLasMetas()
        {
            if (webDriver.Url == "http://localhost:8080/dashboard")
            {
                Console.Write("Mirando Progreso de Profesor Omar");
            }
        }
    }
}