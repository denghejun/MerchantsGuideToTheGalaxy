## What's This
 This `.sln` is a homework about Guide To The Galaxy!!
 
## Where Is The Source
All of source codes already push to GitHub:  [https://github.com/denghejun/MerchantsGuideToTheGalaxy.git](https://github.com/denghejun/MerchantsGuideToTheGalaxy.git).

## How To Run
#### Only 2 Projects Can Run By Press `F5` Directly in `VisualStudio IDE`
###### 1. GuideConsole
Contains the product source codes, it was only read data from file.
* Please make sure has  a  `data.txt` file exists under the root directory of current application (`GuideConsole.exe`).
* Now you can double click `GuideConsoles.exe` to run. Sure! May be you should modify the `data.txt` to input some test data first.

###### 2. GuideToTheGalaxy.Tests
Contains the unit test codes of Biz logic objects.
* It was a test console app by design.
* Please press `F5` to run all unit tests in `VisualStudio IDE` or double click `GuideToTheGalaxy.Tests.exe` directly.



## Design Tips
###### RomanNumerals
Contains all `Roman Codes` and Rules. And has a `RomanCaculator`, it was used to calculate a serial RomanNumbers, like below:
```
 var calculator = new RomanCalculator();
 calculator.Add(RomanNumber.I);
 calculator.Add(RomanNumber.X);
 var value = calculator.Value; //value will be IX = 9
```

###### GuideToTheGalaxy.Commands
Contains many `micro directives` which can execute its command to solve the user input.

* Each static method of `command` as a public API to communicate with other `command`.
* The purpose of `directive` & `command` was separate `Action` from `Data`.
* The inherit of command means which `directive` will be supported by current `command`.
* The inherit of directive means which `Command` can be executed by current `directive`.

To define a new `command` and `directive` like below：
```
    public class UnknownCommand : Command<UnknownCommandDirective>
    {
        public UnknownCommand(UnknownCommandDirective directive) : base(directive)
        {

        }

        public override object Execute()
        {
            return this._directive.Message;
        }
    }
```
```
    public class UnknownCommandDirective : CommandDirective<UnknownCommand>
    {
        public UnknownCommandDirective(string content) : base(content)
        {
        }

        public string Message
        {
            get
            {
                return "I have no idea what you are talking about";
            }
        }

        public override UnknownCommand Command
        {
            get
            {
                return new UnknownCommand(this);
            }
        }
    }
```

And you can use `directive` like below:
```
var result = DirectiveProxy<UnknownCommandDirective>.Create("whatever you want").Command.Execute();
```

one of test samples like below:
```
DirectiveProxy<AliasCommandDirective>.Create("glob is I").Command.Execute();
DirectiveProxy<AliasCommandDirective>.Create("prok is V").Command.Execute();
DirectiveProxy<AliasCommandDirective>.Create("pish is X").Command.Execute();
DirectiveProxy<AliasCommandDirective>.Create("tegj is L").Command.Execute();
DirectiveProxy<UnitPriceCommandDirective>.Create("glob glob Silver is 34 Credits").Command.Execute();
var response = DirectiveProxy<HowManyCommandDirective>.Create("how many Credits is glob prok Silver ?").Command.Execute();

Assert.That(response?.ToString(), Is.EqualTo("glob prok Silver is 68 Credits"));
            
```
