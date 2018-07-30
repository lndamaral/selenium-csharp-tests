## Selenium CSharp Tests

### Setup

This is a automation architecture for C# language.

 1. Cloning the repository:

    ```shell
    git clone https://github.com/lndamaral/selenium_csharp_tests.git
    ```


### Architecture

    /Framework:

        Base/                           # Super classes for Elements, Pages and Tests.
            BaseElement.cs          
            BasePage.cs             
            BaseTest.cs

        Driver/                         # Used to manage drivers.
            Chrome.cs            
            Firefox.cs              

        Helper/                         # Used to keep useful methods for common Selenium operations
            DatabaseFactory.cs            
            DriverFactory.cs
            General.cs
            WaitUntil.cs
            
    /Test.UI.[System Name]:             # Project that references the system is being automated.
        
        Page/                           # Folder where classes that implement pages mapping according to PageObjects.
            [PageName]Page.cs
            [PageName]Page.cs
            [PageName]Page.cs

        Test/                            # Folder where test cases are kept.
            [TestName]Test.cs
            [TestName]Test.cs
            [TestName]Test.cs

        app.config                       # File where all variables needed to run the tests are kept.
        AssemblyInfo.cs                  # File where the level of parallelism is set.

### Test Execution

 1. Local Execution
 
    Set `False` at `<add key="Remote" value="   [here]   " />` in app.config file.
    
 2. Remote Execution
 
    Set `True` at `<add key="Remote" value="   [here]   " />` in app.config file and make sure the Selenium Server is up and running at URL set at `<add key="SeleniumServerURL" value="http://localhost:4444/wd/hub"/>`.
    
 3. Parallel Execution
 
    Set `[assembly: LevelOfParallelism(   [here]   )]" />` the number of parallel executions in AssemblyInfo.cs file.
 
### Docker Compose

    cd path/to/selenium_csharp_tests
    
    docker-compose up -d --scale chrome=3
