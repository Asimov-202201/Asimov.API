using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US008
    {
        
        private static WebDriver webDriver;
        public US008()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
        }
        
        [Given(@"el director se encuentra en la sección “Announcements”")]
        public void GivenElDirectorSeEncuentraEnLaSeccionAnnouncements()
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
            webDriver.Navigate().GoToUrl("http://localhost:8080/announcements");
        }

        [When(@"ingresa los datos del formulario de nuevo anuncio")]
        public void WhenIngresaLosDatosDelFormularioDeNuevoAnuncio()
        {
            var tboxTitle = webDriver.FindElement(By.XPath("//*[@id='input-26']"));
            var tboxDescription = webDriver.FindElement(By.XPath("//*[@id='input-27']"));
            
            tboxTitle.SendKeys("test");
            tboxDescription.SendKeys("test");
        }

        [When(@"presiona el botón submit")]
        public void WhenPresionaElBotonSubmit()
        {
            
            var btnSubmit = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div[1]/div[2]/div/div/button"));
            btnSubmit.Click();
        }

        [Then(@"recibira un mensaje de publicación exitosa")]
        public void ThenRecibiraUnMensajeDePublicacionExitosa()
        {
            //*[@id="app"]/div/main/div/div/div[2]/div/div[1]
            if (webDriver.Url == "http://localhost:8080/announcements")
            {
                Console.Write("Publicado con exito");
            }
        }

        [When(@"no ingresa todos los datos del formulario de nuevo anuncion")]
        public void WhenNoIngresaTodosLosDatosDelFormularioDeNuevoAnuncion()
        {
            var tboxTitle = webDriver.FindElement(By.XPath("//*[@id='input-26']"));
            
            tboxTitle.SendKeys("test");
        }

        [Then(@"observara un mensaje de faltan datos requeridos")]
        public void ThenObservaraUnMensajeDeFaltanDatosRequeridos()
        {
            //*[@id="app"]/div/main/div/div/div[2]/div/div[1]
            if (webDriver.Url == "http://localhost:8080/announcements")
            {
                Console.Write("Faltan datos requeridos");
            }
        }

        [When(@"no hay docentes registrados")]
        public void WhenNoHayDocentesRegistrados()
        {
            if (webDriver.Url == "http://localhost:8080/announcements")
            {
                Console.Write("no hay docentes registrados");
            }
        }

        [Then(@"aparecerá el mensaje de error")]
        public void ThenApareceraElMensajeDeError()
        {
            if (webDriver.Url == "http://localhost:8080/announcements")
            {
                Console.Write("no hay docentes registrados");
            }
        }
    }
}