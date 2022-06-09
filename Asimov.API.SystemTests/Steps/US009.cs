using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US009
    {
        private static WebDriver webDriver;

        public US009()
        {
            webDriver = new ChromeDriver(@"C:\Development\2201\si656\Asimov.API\Asimov.API.Tests\drivers");
        }
        
        [Given(@"el director se encuentra el menú de la aplicación")]
        public void GivenElDirectorSeEncuentraElMenuDeLaAplicacion()
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

        [When(@"seleccione ver listado de docentes")]
        public void WhenSeleccioneVerListadoDeDocentes()
        {
            var waitSideMenu = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            var sideMenuDirector = waitSideMenu.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/header/div/button[1]/span/i")));
            sideMenuDirector.Click();
            
            webDriver.Navigate().GoToUrl("http://localhost:8080/teachers");
        }

        [Then(@"podrá visualizar la información de todos los docentes de su institución")]
        public void ThenPodraVisualizarLaInformacionDeTodosLosDocentesDeSuInstitucion()
        {
        }

        [Then(@"aparecerá un mensaje “no existen docentes registrados para esta institución”")]
        public void ThenApareceraUnMensajeNoExistenDocentesRegistradosParaEstaInstitucion()
        {
            
        }

        [Then(@"aparecerá un mensaje “error interno: no se ha podido acceder a esta información”")]
        public void ThenApareceraUnMensajeErrorInternoNoSeHaPodidoAccederAEstaInformacion()
        {
            
        }
    }
}