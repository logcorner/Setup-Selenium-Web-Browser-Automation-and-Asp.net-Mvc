# Setup-Selenium-Web-Browser-Automation-and-Asp.net-Mvc
There exist many kind of test: unit tests, integration tests, acceptance test…, UI tests.
In this tutorial, I will be interested on UI tests, indeed this kind of test, allows us to validate the IHM by launching the browser, clicking on elements and verify the result. So we can validate the behavior of the application on many browsers: chrome, safari, Firefox, internet explorer, etc…We can also use a specific version of a browser: for sample IE9.
In this tutorial, we will not show how to write Selenium tests in details but we will focus on browser automation in order to execute UI tests on a build environment.
So, let’s go ahead and create an asp.net mvc web project and a Unit Test Project:
install-package Selenium.WebDriver
install-package Selenium.Chrome.WebDriver
install-package SpecFlow
install-package SpecFlow.NUnit
install-package NUnit3TestAdapter
