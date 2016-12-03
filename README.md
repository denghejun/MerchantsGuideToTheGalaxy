## What's This
 This `.sln` is a homework about Guide To The Galaxy!!
 
## Where Is The Source
* All of source codes already push to GitHub:  [https://github.com/denghejun/MerchantsGuideToTheGalaxy.git](https://github.com/denghejun/MerchantsGuideToTheGalaxy.git).

## How To Run
#### Only 2 Projects Can Run By Press `F5` Directly
###### 1. BizConsole
Contains the product source codes, it was only read data from file.
* Please make sure has  a  `data.txt` file exists under the root directory of current application (`BizConsole.exe`).
* Now you can click `BizConsole.exe` to run. Sure! May be you should modify the `data.txt` to input some test data first.

###### 2. GuideToTheGalaxy.Tests
Contains the unit test codes of Biz logic objects.
* It was a test console app by design.
* Please press `F5` to run all unit tests.



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
Contains many directives which can execute its command to solve the user input. one of samples like below:
```
DirectiveProxy<AliasCommandDirective>.Create("glob is I").Command.Execute();
DirectiveProxy<AliasCommandDirective>.Create("prok is V").Command.Execute();
DirectiveProxy<AliasCommandDirective>.Create("pish is X").Command.Execute();
DirectiveProxy<AliasCommandDirective>.Create("tegj is L").Command.Execute();
DirectiveProxy<UnitPriceCommandDirective>.Create("glob glob Silver is 34 Credits").Command.Execute();
var response = DirectiveProxy<HowManyCommandDirective>.Create("how many Credits is glob prok Silver ?").Command.Execute();

Assert.That(response?.ToString() == "glob prok Silver is 68 Credits");
            
```