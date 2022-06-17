using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US030
    {
        private static WebDriver webDriver;
        public US030()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
        }
        
        [Given(@"el docente esté desarrollando un curso")]
        public void GivenElDocenteEsteDesarrollandoUnCurso()
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
            var ingresarCurso = waitIngresarCurso.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div[2]/div/div/div[2]/div[3]/a/span")));
            ingresarCurso.Click();
        }

        [When(@"haya completado todos los ítems del curso")]
        public void WhenHayaCompletadoTodosLosItemsDelCurso()
        {
            var waitBtnItemDocumentation = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemDocumentation = waitBtnItemDocumentation.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div/div[2]/div[1]/div[1]/div/div/div[2]/button")));
            btnItemDocumentation.Click();
            
            var waitBtnItemComplete = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemComplete = waitBtnItemComplete.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/button[2]")));
            btnItemComplete.Click();
            
            var waitBtnItemVideo = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemVideo = waitBtnItemDocumentation.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[2]/main/div/div/div/div[2]/div[1]/div[2]/div/div/div[2]/button/span")));
            btnItemVideo.Click();
            
            var waitBtnItemComplete2 = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemComplete2 = waitBtnItemComplete2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[4]/div/div/div[3]/button[2]")));
            btnItemComplete2.Click();
        }

        [Then(@"el progreso del profesor aumentará")]
        public void ThenElProgresoDelProfesorAumentara()
        {
        }

        [Given(@"el docente esté desarrollando algún curso")]
        public void GivenElDocenteEsteDesarrollandoAlgunCurso()
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
            var ingresarCurso = waitIngresarCurso.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div[2]/div/div/div[3]/div[3]/a/span")));
            ingresarCurso.Click();
        }

        [When(@"no haya completado todos los ítems del curso")]
        public void WhenNoHayaCompletadoTodosLosItemsDelCurso()
        {
            var waitBtnItemDocumentation = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemDocumentation = waitBtnItemDocumentation.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div/div[2]/div[1]/div[1]/div/div/div[2]/button")));
            btnItemDocumentation.Click();
            
            var waitBtnItemComplete = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemComplete = waitBtnItemComplete.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/button[2]/span")));
            btnItemComplete.Click();
        }

        [Then(@"el progreso del profesor no aumentará")]
        public void ThenElProgresoDelProfesorNoAumentara()
        {
        }

        [Given(@"el docente esté desarrollando cierto curso")]
        public void GivenElDocenteEsteDesarrollandoCiertoCurso()
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
            var ingresarCurso = waitIngresarCurso.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div[2]/div/div/div[4]/div[3]/a/span")));
            ingresarCurso.Click();
        }

        [When(@"haya completado cada uno de los ítems del curso")]
        public void WhenHayaCompletadoCadaUnoDeLosItemsDelCurso()
        {
            var waitBtnItemDocumentation = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemDocumentation = waitBtnItemDocumentation.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/main/div/div/div/div[2]/div[1]/div[1]/div/div/div[2]/button")));
            btnItemDocumentation.Click();
            
            var waitBtnItemComplete = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemComplete = waitBtnItemComplete.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/button[2]")));
            btnItemComplete.Click();
            
            var waitBtnItemVideo = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemVideo = waitBtnItemDocumentation.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[2]/main/div/div/div/div[2]/div[1]/div[2]/div/div/div[2]/button/span")));
            btnItemVideo.Click();
            
            var waitBtnItemComplete2 = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var btnItemComplete2 = waitBtnItemComplete2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div[4]/div/div/div[3]/button[2]")));
            btnItemComplete2.Click();
        }

        [Then(@"el curso aparecerá como completado en la lista de cursos del docente\.")]
        public void ThenElCursoApareceraComoCompletadoEnLaListaDeCursosDelDocente()
        {
        }
    }
}