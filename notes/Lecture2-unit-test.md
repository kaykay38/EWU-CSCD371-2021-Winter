Jan 7, 2020 <br>
CSCD 371 - .NET Programming<br>
## Lecture 2 
#### Unit Tests
- **Test-driven development** - write tests before full implementation (use simplest implementations)
- **Code coverage** 
    - Can have bugs even if there is 100% code coverage because of bad tests.<br>
- **Naming conventions**<p>
    - Do not use abbreviations unless standard abbreviations<br>
    - Naming conventions matter!!!<br>
    - Always use camel case<br>
- **Test order should not matter for success of tests**
- **Propertie** prefered over **fields**
##### Visual Studio features & shortcuts
- Live Unit Testing (Enterprise only?) 
-
-
#### .NET Features
`_= new Application()` - .NET 8 discard feature


\*\*Mark Capka taking notes feel free to make suggested edits

_NOTE: In class code is pretty fragmented to note particular pieces, all code is available under todays lecture in the class git i&#39;ll add as I can and will remove this message once I add in the code. I will also upload everything to my github tomorrow for versioning control_

_**Action Items from Thursday (today)**_

- _**Assignment 1 (by Monday EOD)**_
- _**Reading chapters 1-6 (by Tuesday)**_
  - _ **Pay attention to** _
    - _ **Pattern matching** _
    - _**Properties (chapter 6, the whole thing and it is foundational) + coding guidelines**_
    - _**Nullibility: Null values and not null values (chapter 2) (hint at end of lecture)**_
- _ **Submit google form if you haven&#39;t already** _
- _ **Reach out via GitterChat if needed** _
- _ **ATTEMPT HOMEWORK BEFORE THURSDAYS TO ENSURE YOU HAVE TIME TO ASK QUESTIONS** _

_ **Action items From Tuesday** _ _Clone to your fork first_

- _Submit the google form for submitting your github id_
- _start reading chapters 1-6_
- _confirm your tools_
- _Start looking at/working on Assignment1_

**Instructors:**

Email address: **EWU-Instructors@IntelliTect.com**

**Mark Michaelis**

**Michael Stokesbury (Mike)**

**Kevin Bost**

**Github Link:** [**https://github.com/IntelliTect-Samples/EWU-CSCD371-2021-Winter\**](https://github.com/IntelliTect-Samples/EWU-CSCD371-2021-Winter%5C)

**Reason for 1-6 chapter upfront reading:** to cover more material in class for our benefit. We should be relatively familiar with the basics at this point, should be more skimming the first 6 chapters since much of it we should be familiar withbased on the fundamentals of other languages like Java.

**Testing:** Advantage of automated testing/unit testing is that it saves us from manually verifying every feature by giving the computer an expectation of the results that your code should have.

**\*Regression testing/retesting:** even after modifying code later, if your original unit test is correct, you will still get verification that your results haven&#39;t changed despite alteration of later code.
**\*\*\*\*that makes knowing how to write and utilize these tests very useful and time saving. We will set up our system to keep our quality high.**

Often it is the subtle mistakes that trip us up. These little subtleties may escape us between the expectation and result but will likely be caught by a properly written test.

**HOW MUCH UNIT TESTING?:** 100% code coverage is difficult, expensive, and unlikely.

0% code coverage is very easy, but potentially very expensive

**Correct:** between 0-100% (lol). Ideally 75%-80% BUT it does depend on the project you are working on, the languages, how intent revealing your code is… **There is no magic answer**

**(HOWEVER) we should be at about 80-90%.**

**TEST DRIVEN DEVELOPMENT Design:**

1. _Write a test to show that you need to write production code._
  1. _Next write the simplest implementation that lets the test pass_
    1. _Refactor_
      1. _Repeat_

_End Result: all qualities are fulfilled, code coverage is high, minimizes duplication of code_

_ **Writing with unit tests is like driving with a seat belt,** _ _there is an absolute correct way to do it (wearing your seatbelt/writing unit tests) and_ _ **once you become familiar with the correct way of doing it and become practiced in doing so, it becomes habit and will feel weird to go without** _ _code without tests, just as it feels weird to drive without a seatbelt after a while._

**Risk is increased drastically as project size increases without unit testing.** This is reflected in industry with additional costs as well to cover for lacks of unit testing, whether testing manually.

**Can you have 100% code coverage and still have bugs?? YES - we can have bad tests or incomplete code.**

Just because a test is written, doesn&#39;t mean that you are writing tests that achieve what you desire, or that fully cover all of the potential bugs.

_I.e_

_[2:26 PM] Kevin Bost (Guest)_

_public void Divide(int a, int b) =\&gt; a / b;_

_[TestMethod]_

_public void RunTest() =\&gt; Assert.AreEqual(2, Divide(4, 2));_

**Exercise following Mark:**

Create Class library project in visual studio:

Project name: LoginStuff

Check box for place solution and project in the same directory.(AT END OF CLASS WE WILL MOVE SOLUTION)

_\*inside the lectures, there will be a folder for the class which will hold the code from the class, video, etc._

_Then right click on &quot;LoginStuff&quot; in solution Explorer and create new Project to house the tests and create Project: LoginStuff.tests_

_[2:34 PM] Kevin Bost (Guest)_

_Naming convention: \&lt;Name Of Project being Tested\&gt;.Tests_

​_[2:36 PM] Kevin Bost (Guest)_

_Solution files just provide organization of projects and files within Visual Studio. VSCode just uses your folder structure._

_ **CommandLine:** _ _find directory you would like the project created in:_ ![](RackMultipart20210108-4-ft2qbp_html_86399d16dbc77d15.png)

_dotnet new classlib -n LoginStuff_

_dir_

_dotnet new mstest -n LoginStuff.Tests_

_dotnet sln add .\LoginStuff\LoginStuff.csproj_

_dotnet sln add .\loginStuff.Tests\LoginStuff.Tests.csproj_

**VIEW:** Test Explorer to run tests (similar to eclipse and other IDE)

**GenerateType:** put in projectLoginStuff: DO THROUGH CODE GEN -follow up on this later for clarity in notes Can use autocode to automatically add dependency

**CommandLine:** go into test project directory:

Dotnet add reference ..\LoginStuff.csproj

h | select -last 6

Code . (will open up VS or your default IDE)

**Powershell is dotnet in command line.**

This means that you can hit . and it will pull up a bunch of options of commands you can do.

I.e. if you type; &quot;this is a test&quot;. Which will give all methods that are available after the dot. Allows us to easily work with a CLI as well while we learn C

**Right click on LoginStuff, add, new item, class, svm /\*for static void main\*/**

Marks&#39; preference is to do the solution directory in the **parent** of directory.

\*create the solution, then add it

\*If we don&#39;t do this, then we may not end up with our solution linked to our other files.

\*solution files are ugly. They give the path and the solution project you are pointing at. If you don&#39;t have it at the parent level, when you move the solution you also have to move the project.

Generally don&#39;t use an abbreviation in C# unless it is an agreed upon ALWAYS used abbreviation. For example: HTML is an accepted abbreviation

\*Because of intellisense, we should just have to declare the name once and intellisense should help suggest the longer names anyway, shouldn&#39;t really increase your typing much.

CONVENTIONS ARE EXTREMELY IMPORTANT \*\*\*\* THEY WILL BE STICKLERS

Classes and Methods: PascalCase:

Local Variables: camelCase

Fields: \_PascalCase (will talk more about later, called &quot;unsderscore pascal case&quot;. )

\*\*\*\*\*\*\*READ AND MEMORIZE THE CODING GUIDELINES\*\*\*\*\*

BEST WAY TO UNDERMINE YOUR EXPERTISE IS TO NOT FOLLOW THE CONVENTIONS

They will tell us how to turn analyzers on so the compiler will tell us if we are violating any of the conventions.

\*\*\*\*PAY ATTENTION TO NAMING AND STYLE

SHORTCUTS: \* MUST MAKE SURE C# shortcuts are installed or selected)

Ctrl + r, t Only works in the context of tests

Ctrl + shift + B Build

Ctrl + f5 runs the program if there is one selected

**code coverage:** can tell us how any of our tests are passing and in which methods they are testing. _To find code coverage -\&gt; go to test view, then drop down and bottom option_

_CODE WITH COVERAGE: might be tested_

_CODE WITHOUT COVERAGE: is NOT tested_

_ **Visual studio enterprise:** _ _can have_ _ **live unit testing** _ _as an option. Likely EWU can probably help you get a login (see 1st day notes on enterprise edition info)_

_ApplicationTests.cs FOR FULL CODE: see the github for todays lecture for the in class code_

_Can be created very quickly thanks to intellisense suggestions._

_ **F12 is your friend:** _ _ **ctrl+.** __Will generate the method, hit enter, should now compile._

_Assert.IsTrue(success)_

_ **\*\*\*\*This generated method does NOT transfer the name of the variables.** _

_ **//incomplete code - will return and try to clarify** _

_\*\*SO another option is to the generation using defined local variables instead._

_I.e. string userName = &quot;Inigo.Montoya&quot;;_

_String password = &quot;OpenSaysMe&quot;_

_Bool success = application.Login(userName, password)_

_Assert.IsTrue(success);_

_Doesn&#39;t matter which type you use as long as you remember to change the name of the parameters. If it isn&#39;t done for you._

_ **Generally -** _ _don&#39;t write code unless it helps make things more clear._

_I.e. the &quot;this&quot; keyword isn&#39;t really needed in C#_

_ **Alt + shift + enter:** _ _maximizes source code real estate on screen_

_ **Alt + arrowKey :** _ _moves your line of code_

_public bool Login(string username, string password)_

_{_

_return password == &quot;OpenSaysMe&quot;;_

_} //this should pass_

_Test fails_

_Write test that passes_

_Refactor_

_[TestMethod]_

_Public void ValidLogin()_

_{_

_ **//Arrange** _

_Application application = new Application();_

_ **//Act** _

_Bool result = application.Login(_

_Assert.IsFalse(application.Login(userName: &quot;Inigo.Montoya&quot;, password: &quot;Bad Password&quot;)))_

_ **//Assert ONLY HAVE ONE ASSERT OTHERWISE IF ONE TEST FAILS THE REST WONT RUN** _

_Assert.IsFalse(result)_

_}_

_ **Then refactor: Since all of our previous tests all create an application it is doing alot of duplicate work so we can refactor to reuse.** _

_ **OK TO NAME THINGS THE SAME AS THE DATA TYPE** _

_I.e. Application Application; as a variable_

_Generally don&#39;t use fields, just use properties._

_ **In C# there are properties:** _

_ **Property:** _ _gives the ability to intercept to validate what you have is going to be set correctly._

_Application Application; //field of data type application_

_ **Ctrl + . :** _ _Enter can be used to rename all of our applications within scope. Really helps with refactoring_

_Public Application Application {_

_Get =\&gt; Application;_

_Set =\&gt; Application = value;_

_}_

_ **Ctrl + alt + click** _ _on the author links that you would like to edit at the same time. There will belinks for places that are suggested to make the changes. This will place the 3 cursors and we can edit those all 3 at once since we are editing the same word, this will save us lots of time and energy._

_ **Properties:** _ _C# supports the ability to have validation on your getters and setters.._

_ **NOTE:** _ _Assert methods are just fancy ways of throwing exceptions with useful error message. Any unit test that does not throw an exception is a success, and any unit test that throws an exception is a failure._

_ **DEBUGGING HOTKEY: f9 for breakpoint** _

_[TestMethod]_

_Public void CheckApplicationIsNull()_

_{_

_Application = null;_

_Assert.IsNull(Application);_

_} // ctrl + r, t_

_If we change the above test method to a property: we can right click and select &quot;encapsulate as property&quot; which will establish Application as:_
_Property:_ _ **Application Application {get; set;}** _

**ALWAYS USE PROPERTIES INSTEAD OF FIELDS UNLESS YOU HAVE TO**

Access from property instead of field

**Properties:** Underscore\_Pascal\_Case

\*allows us to do interception

**\*\*properties start with underscore**

_So we will change our previously listed getters and setterS:_

_Public Application Application:_

_{_

_get =\&gt; \_Application;_

_set =\&gt; \_Application = value ??_

_Throw new ArgumentNullException(nameof(value));_

_}_

_Ultimately, getters and setters are first class properties that allow us to verify the getters and setters in C#, unlike Java where we had to have fields, then getters and setters to fetch them._

_In C# we can check our getters to determine if they are retrieving something valid._

_So for example, we could set it so that \_Application cannot be null._

_ **F11: Debugging: Step In** _

_IF WE RUN OUR TESTS IN A DIFFERENT ORDER IT MAY AFFECT THE RESULTS._

_UNIT TESTS SHOULDN&#39;T AFFECT EACH OTHER. IF A TEST FAILS OR SUCCEEDS ANY PREVIOUS OR FUTURE TESTS SHOULDN&#39;T BE IMPACTED._

_[TestInitialize]_

_Public void Setup()_

_{_

_Console.WriteLine(&quot;Inside Setup&quot;);_

_Application = new Application();_

_}_

_//gives every single test a new instance of the application_
