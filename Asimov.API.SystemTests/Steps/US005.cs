using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Asimov.API.Tests.Stepdefs
{
    [Binding]
    public class US005
    {
        private static WebDriver webDriver;
        public US005()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));        }
        [Given(@"el docente se encuentra en el formulario de registro de usuario")]
        public void GivenElDocenteSeEncuentraEnElFormularioDeRegistroDeUsuario()
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/sign-up");
        }
        
        [Given(@"ingresa toda la información solicitada")]
        public void GivenIngresaTodaLaInformacionSolicitada()
        {
            var tboxFirstName = webDriver.FindElement(By.XPath("//*[@id='input-35']"));
            var tboxLastName = webDriver.FindElement(By.XPath("//*[@id='input-38']"));
            var tboxAge = webDriver.FindElement(By.XPath("//*[@id='input-41']"));
            var tboxEmail = webDriver.FindElement(By.XPath("//*[@id='input-44']"));
            var tboxPassword = webDriver.FindElement(By.XPath("//*[@id='input-47']"));
            var tboxPhone = webDriver.FindElement(By.XPath("//*[@id='input-50']"));
            var radioTeacher = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div[1]/div[2]/form/div[7]/div[1]/div[1]/div/div[2]/div/div"));

            radioTeacher.Click();
            var comboDirector = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div[1]/div[2]/form/div[8]/div/div/div[1]/div[1]"));
            comboDirector.Click();
            
            tboxFirstName.SendKeys("test");
            tboxLastName.SendKeys("test");
            tboxAge.SendKeys("21");
            
            Random rand = new Random();
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < 5; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }
            tboxEmail.SendKeys(str + "@gmail.com");
            tboxPassword.SendKeys("test");
            tboxPhone.SendKeys("999999999");
            radioTeacher.Click();
            
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));          
            var optJulio = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='list-item-77-0']/div/div")));
            optJulio.Click();
        }

        [When(@"da click en el botón de registrarse")]
        public void WhenDaClickEnElBotonDeRegistrarse()
        {
            var btnSubmit = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div[1]/div[3]/button[2]/span"));
            btnSubmit.Click();
        }

        [Then(@"logra ingresar al dashboard de la aplicación")]
        public void ThenLograIngresarAlDashboardDeLaAplicacion()
        {
            if (webDriver.Url == "http://localhost:8080/")
            {
                Console.Write("Ingresó con éxito");
            }
        }
        
        [Given(@"ingresa al menos un dato invalido")]
        public void GivenIngresaAlMenosUnDatoInvalido()
        {
            var tboxEmail = webDriver.FindElement(By.XPath("//*[@id='input-44']"));
            tboxEmail.SendKeys("test");
            
            var lblEmailMessage = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div[1]/div[2]/form/div[4]/div/div[2]/div/div/div"));
            if (lblEmailMessage.Text == "E-mail must be valid")
            {
                Console.Write("Email invalido");
            }
        }
        
        
        [Then(@"no habrá ninguna respuesta")]
        public void ThenNoHabraNingunaRespuesta()
        {
            if (webDriver.Url == "http://localhost:8080/sign-up")
            {
                Console.Write("Sin respuesta");
            }
        }

        [Given(@"ingresa informacion de un usuario ya registrado")]
        public void GivenIngresaInformacionDeUnUsuarioYaRegistrado()
        {
            var tboxFirstName = webDriver.FindElement(By.XPath("//*[@id='input-35']"));
            var tboxLastName = webDriver.FindElement(By.XPath("//*[@id='input-38']"));
            var tboxAge = webDriver.FindElement(By.XPath("//*[@id='input-41']"));
            var tboxEmail = webDriver.FindElement(By.XPath("//*[@id='input-44']"));
            var tboxPassword = webDriver.FindElement(By.XPath("//*[@id='input-47']"));
            var tboxPhone = webDriver.FindElement(By.XPath("//*[@id='input-50']"));
            var radioTeacher = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div[1]/div[2]/form/div[7]/div[1]/div[1]/div/div[2]/div/div"));
            
            radioTeacher.Click();
            var comboDirector = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div[1]/div[2]/form/div[8]/div/div/div[1]/div[1]"));
            comboDirector.Click();
            
            tboxFirstName.SendKeys("test");
            tboxLastName.SendKeys("test");
            tboxAge.SendKeys("21");
            tboxEmail.SendKeys("omar@gmail.com");
            tboxPassword.SendKeys("test");
            tboxPhone.SendKeys("999999999");
            
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));          
            var optJulio = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='list-item-77-0']/div/div")));
            optJulio.Click();
        }

        [When(@"intenta dar click en el botón de registrarse")]
        public void WhenIntentaDarClickEnElBotonDeRegistrarse()
        {
            var btnSubmit = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div[1]/div[3]/button[2]/span"));
            if (btnSubmit.Enabled == false)
            {
                Console.Write("No se puede clickear");
            }
        }
    }
}