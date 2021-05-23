# e2e-specflow-selenium-framework
Refactor Specflow calculator end to end tests project with customized selenium framework and page factory pattern.
I have re-write the Calculator Steps defenitions with this approach


1- find the Config.cs file and change the base path to your project

2- in each page there is a path for joining the base path to the path under test

3- find an appropriate element id or unique css selector for identifier of the page

4- there is also components like headers, footers, modals, which are not a complete page, take advantage of componentbase class to create them.

5- follow the classes in Manipulators which covers many variety of interations with web elements.

# things to consider:
Be carefull to check the chrome driver on the project and the version of chrome installed on your machine.
  if they are not the same make them the same version by updating Selenium.Driver.ChromeDriver nuget package.
