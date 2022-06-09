using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US012
    {
        private static WebDriver webDriver;
        public US012()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));        }

    [Given(@"el director se encuentra en el menú de la aplicación")]
        public void GivenElDirectorSeEncuentraEnElMenuDeLaAplicacion()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/sign-up");
            var btnGoLogin =
                webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div[2]/div/a/span"));
            btnGoLogin.Click();
            var tbxEmail = webDriver.FindElement(By.Id("input-76"));
            tbxEmail.SendKeys("julio@gmail.com");

            var tbxPassword = webDriver.FindElement(By.Id("input-81"));
            tbxPassword.SendKeys("yulius15");

            var radiousTeacher = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div/div[2]/form/div[3]/div[1]/div[1]/div/div[1]/div/div"));
            radiousTeacher.Click();

            webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[3]/button[2]/span")).Click();
        }

        [Given(@"hace click al apartado de historial de planificación de competencias")]
        public void GivenHaceClickAlApartadoDeHistorialDePlanificacionDeCompetencias()
        {
            var waitSideMenu = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            var sideMenuDirector = waitSideMenu.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/header/div/button[1]/span/i")));
            sideMenuDirector.Click();
            webDriver.Navigate().GoToUrl("http://localhost:8080/competences");
        }

        [When(@"haga click en la opción de agregar una planificación")]
        public void WhenHagaClickEnLaOpcionDeAgregarUnaPlanificacion()
        {
        }

        [Then(@"podrá elegir una planificación de competencias para agregarlo")]
        public void ThenPodraElegirUnaPlanificacionDeCompetenciasParaAgregarlo()
        {
        }

        [Then(@"se mostrará el mensaje “Actualmente no existen competencias a planificar”")]
        public void ThenSeMostraraElMensajeActualmenteNoExistenCompetenciasAPlanificar()
        {
            
        }

        [Then(@"se mostrará el mensaje “Error interno: no se ha podido acceder a la información”")]
        public void ThenSeMostraraElMensajeErrorInternoNoSeHaPodidoAccederALaInformacion()
        {
            
        }
    }
}