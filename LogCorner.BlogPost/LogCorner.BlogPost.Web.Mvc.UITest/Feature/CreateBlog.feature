Feature: CreateBlog

Scenario: When no Authenticated User attempt to create a blogPost , it must be redirected on login page
	Given I m an anonymous user
	When I naviagte to blog list page
	And  I click on Create New Blog link
	Then  I must be redirected on login page


#
#Scenario: When no Authenticated User attempt to create a blogPost , it must be redirected on login page 
#	Given I m an anonymous user
#	When I naviagte to blog list page
#	And  I click on Create New Blog link
#	Then  I must be redirected on login page
#	When  I logged in selenium@yopmail.com Selenium1#
#	Then I must be redirected on CreateBlogPage
#	When I enter url https://logcorner2.com and description Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s and click on create button
#	Then I must be redirected on list of blog page
#	And my newly created blog will be displayed on that page

	#
	#Scenario: When Authenticated User attempt to create a blogPost , it must be redirected on create blog page xxx
	#Given I m an authenicated user selenium@yopmail.com Selenium1#
	#When I naviagte to blog list page
	#And  I click on Create New Blog link
	#Then I must be redirected on CreateBlogPage
	#When I enter url https://logcorner2.com and description Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s and click on create button
	#Then I must be redirected on list of blog page
	#And my newly created blog will be displayed on that page

	

