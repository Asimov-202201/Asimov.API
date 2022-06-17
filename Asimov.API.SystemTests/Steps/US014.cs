using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US014
    {
        private static WebDriver webDriver;
        public US014()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
        }
        
        [Given(@"el docente está ubicado en el Dash Board de la aplicación")]
        public void GivenElDocenteEstaUbicadoEnElDashBoardDeLaAplicacion()
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
        }

        [When(@"seleccione la opción de cursos en la barra izquierda")]
        public void WhenSeleccioneLaOpcionDeCursosEnLaBarraIzquierda()
        {
            var waitSideMenu = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            var sideMenuTeacher = waitSideMenu.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/header/div/button[1]/span/i")));
            sideMenuTeacher.Click();
            webDriver.Navigate().GoToUrl("http://localhost:8080/courses");
        }

        [Then(@"visualiza los cursos que llevará a cabo en la semana\.")]
        public void ThenVisualizaLosCursosQueLlevaraACaboEnLaSemana()
        {
        }

        [Given(@"el docente se encuentra en la sección de cursos")]
        public void GivenElDocenteSeEncuentraEnLaSeccionDeCursos()
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
        }

        [When(@"seleccione la opción “ver detalle” de algún curso")]
        public void WhenSeleccioneLaOpcionVerDetalleDeAlgunCurso()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/courses");
            var waitIngresarCurso = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            var ingresarCurso = waitIngresarCurso.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div[2]/div/div/div[2]/div[3]/a/span")));
            ingresarCurso.Click();
        }

        [Then(@"visualiza el contenido de la semana de dicho curso\.")]
        public void ThenVisualizaElContenidoDeLaSemanaDeDichoCurso()
        {
        }
    }
}