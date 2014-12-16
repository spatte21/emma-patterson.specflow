Feature: Browsing the website
	Ensure the site loads and the navigation links work as expected

	Scenario: Check that the site Loads
		Given I have browsed to the site 'http://emma-patterson.co.uk'
		Then I should see the site homepage

	Scenario Outline: Check that the navigation links work correctly
		Given I have browsed to the site 'http://emma-patterson.co.uk'
		When I click the '<Page>' Navigation Link
		Then the text '<TitleText>' should be displayed in the page title
	Examples:
		| Page       | TitleText                                   |
		| Home       | Dear Parents/Carers,                        |
		| EYFS       | Early Years Foundation Stage (Revised 2012) |
		| Policies   | Policies                                    |
		| Times/Fees | Times and Fees                              |
		| Misc.      | Miscellaneous Information                   |
		| Gallery    | Our Gallery                                 |
		| Contacts   | Contact Details                             |
