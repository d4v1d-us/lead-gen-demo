# lead-gen-demo
lead generation and real-time application processing for sub-prime loans demo

Landing Page (short application)

- The landing Page will have a focused objective with the Call to Action --> Short Application.
- The Short Application form will have the input fields, Loan Amount, First Name, Last Name, Email Address, State, Zip Code and check box indicating agreement to the Terms and Conditions, apply now button.
- The Apply Now button will validate the input fields, save the Short Application as a lead to the database and progress the consumer to the full application (Secure Application).

[Landing Page Image](https://github.com/d4v1d-us/liftoff-assignments/blob/master/P3-Project_Planning/1.landingpage.jpg)

Secure Application (full application)
- The Secure Application page will display the Full Application form.
- The Full Application for will have 3 sections Personal Information, Employment Information, Banking Information with the input fields,


-Personal Information 

	Your name:
		First Name, Last Name, 

	Your address:
		Street Address, Street Address2, City, State, Zip Code

	Residence details:
		Months at Address: years, months, Homeowner

	Contact details:
		Email Address, Alternate Email, Cell/Best Phone, Home/Alternate Phone

	Your birthdate:
		Birthdate, year, Are you Active or Ex Military

	Two References:
		1st Full Name, 1st Phone No, 1st Relationship
		2nd Full Name, 2nd Phone No, 2nd Relationship

-Employment Information 

	Employment details:
		Employer Name, Months Employed, Work Phone No, Work Phone Ext

	Income details:
		Type of Income, Pay Frequency, Pay per Period, Direct Deposit, Next Payday, 2nd Payday

-Banking Information 

 	Bank details:
		Bank Name, Months at Bank: years months, Account Type, Bank ABA No, Account No

	Identification details:
		Social Security No, Drivers License No, Drivers State
 
	Cash Loan details:
		Loan Amount, I Agree
		
	Send Application: Apply Now Button

- The Apply Now Button will validate the input fields, save the application to the database and proceed to the Secure Approval page.

[Secure Application Image](https://github.com/d4v1d-us/liftoff-assignments/blob/master/P3-Project_Planning/2.secure.application.jpg)
	
Secure Approval

- The Secure Approval page will format application data into proper XML format for affiliate lead buyers.
- Send the lead real-time through affiliate lead buyers API ping tree, process the lead buyers ping tree response and save to database.
- This process is repeated for any number of affiliate lead buyers configured.
- If a response of accepted is returned the lead ping tree process is stopped and the consumer is shown the Congratulations page.
- If the consumer does not qualify for any lead buyers, the consumer is shown the Additional Resources page.
- Secure Approval displays application processing status information to the consumer.

[Secure Approval Image](https://github.com/d4v1d-us/liftoff-assignments/blob/master/P3-Project_Planning/3.secure.approval.JPG)

Congratulations

- The Congratulations page will display the approval message, link to the lead buyer and redirect the consumer to finish any required documents to complete the loan.

[Congratulations Image](https://github.com/d4v1d-us/liftoff-assignments/blob/master/P3-Project_Planning/4.congratulations.JPG)

Additional Resources

- The Congratulations page will display a status message to the consumer that their application was not successfully matched with a lead buyer in real-time.
- Additional affiliate offer links will be displayed to the consumer.
	
[Additional Resources Image](https://github.com/d4v1d-us/liftoff-assignments/blob/master/P3-Project_Planning/5.additional.resources.JPG)
