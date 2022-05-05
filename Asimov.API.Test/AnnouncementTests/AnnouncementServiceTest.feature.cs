﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Asimov.API.Test.AnnouncementTests
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AnnouncementServiceTestsFeature : object, Xunit.IClassFixture<AnnouncementServiceTestsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AnnouncementServiceTest.feature"
#line hidden
        
        public AnnouncementServiceTestsFeature(AnnouncementServiceTestsFeature.FixtureData fixtureData, Asimov_API_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AnnouncementTests", "AnnouncementServiceTests", "As a Director\r\nI want to add new Announcement through Application\r\nSo that It can" +
                    " be available to all teachers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
    #line hidden
#line 7
        testRunner.Given("the Endpoint https://localhost:5001/api/v1/announcements is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "Age",
                        "Email",
                        "Password",
                        "Phone"});
            table1.AddRow(new string[] {
                        "1",
                        "Ricardo",
                        "De la Cruz",
                        "42",
                        "ric.cruz1212@gmail.com",
                        "Ss924@d#p_s",
                        "918274009"});
#line 8
        testRunner.And("A Director is already stored", ((string)(null)), table1, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add Announcement")]
        [Xunit.TraitAttribute("FeatureTitle", "AnnouncementServiceTests")]
        [Xunit.TraitAttribute("Description", "Add Announcement")]
        [Xunit.TraitAttribute("Category", "announcement-adding")]
        public virtual void AddAnnouncement()
        {
            string[] tagsOfScenario = new string[] {
                    "announcement-adding"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Announcement", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 13
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Description",
                            "DirectorId"});
                table2.AddRow(new string[] {
                            "Meeting 1",
                            "New competences to be added",
                            "1"});
#line 14
        testRunner.When("A Post Request to Announcement is sent", ((string)(null)), table2, "When ");
#line hidden
#line 17
        testRunner.Then("A Response with Status 200 is received in Announcement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Description",
                            "DirectorId"});
                table3.AddRow(new string[] {
                            "Meeting 1",
                            "New competences to be added",
                            "1"});
#line 18
        testRunner.And("A Announcement Resource is included in Response Body", ((string)(null)), table3, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add Announcement with Invalid Director")]
        [Xunit.TraitAttribute("FeatureTitle", "AnnouncementServiceTests")]
        [Xunit.TraitAttribute("Description", "Add Announcement with Invalid Director")]
        public virtual void AddAnnouncementWithInvalidDirector()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Announcement with Invalid Director", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 22
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Description",
                            "DirectorId"});
                table4.AddRow(new string[] {
                            "Meeting 2",
                            "Updating competences",
                            "-1"});
#line 23
        testRunner.When("A Post Request to Announcement is sent", ((string)(null)), table4, "When ");
#line hidden
#line 26
        testRunner.Then("A Response with Status 400 is received in Announcement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
        testRunner.And("A Message of \"Invalid Director\" is included in Response Body of Announcement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AnnouncementServiceTestsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AnnouncementServiceTestsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion