Feature: Buy Energy

As a test user,
I want to access buy energy page,
So that I can test the buy energy options for different types

@regression
Scenario: Go back to homepage from buy energy page
	Given the user in homepage
	When the user clicks buy energy button
	Then the user should be launched in buyEnergyPage
	And the user clicks the Back to Homepage link
	Then the user should be in home page

@regression
Scenario Outline: Reset the purchase unit values 
	Given the user in buyEnergyPage
	And the user fill the <fuel> number of units required value as <purchase_unit>
	And the user clicks the reset button
	Then the number of units required values are reset to default values for <fuel>
Examples:
| fuel        | purchase_unit |
| Gas         | 35            |
| Electricity | 20            |
| Oil         | 7             |

@regression
Scenario Outline: Buy all energy type
	Given the user in buyEnergyPage
	And the user fill the <fuel> number of units required value as <purchase_unit>
	And the user clicks the <fuel> buy button
	Then the user validates the sale confirmation message

Examples:
| fuel        | purchase_unit |
| Gas         | 35            |
| Electricity | 20            |
| Oil         | 7             |