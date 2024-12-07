This sample project is an upgrade from Coding Tutorials - https://www.youtube.com/watch?v=T5spUmVMkVU - tutorial on .NET reflections. 

This tutorial has been further upgraded not to only show a single object in CSV but 1:1 and 1:M relationships. 

Example 1:1 relationship
Id	Name	  Price    	Maker		
1	  MX-5	  3000.5	  Mazda Motor Corporation	Mazda	1
2	  MX-30	  5000.5	  Mazda Motor Corporation	Mazda	1
3	  CX-3	  31000.5	  Mazda Motor Corporation	Mazda	1
4	  CX-30	  39000.5	  Mazda Motor Corporation	Mazda	1
5	  CX-8	  20030.5	  Mazda Motor Corporation	Mazda	1
6	  iX M60	30700.5	  Bayerische Motoren Werke GmbH	BMW	2
7	  BMW i7	23000.5	  Bayerische Motoren Werke GmbH	BMW	2
8	  BMW i5	13000.5	  Bayerische Motoren Werke GmbH	BMW	2
![image](https://github.com/user-attachments/assets/cac8e122-50e3-47f3-9af6-a848c695772d)

Example 1:M relationship

Id	UniqueId	                            DateOrdered	Value	  BasketItems_Name	                                   BasketItems_Price     BasketItems_Id
1	  cf1c60f4-ea65-4160-acbc-088dbda2935e	2024-12-07	1801.16	Nvidia 4090;  Kingston 3444 MHZ 32GB 2x16GB	1500.75; 300.41	               1; 2
2	  231f195f-cec7-44c9-bb9b-d2cf753585e7	2024-12-07	4.91	  Toilet paper; Bread; Milk	                           2.37; 1.55; 0.99	     3; 4; 5
![image](https://github.com/user-attachments/assets/1a570327-1d49-43b2-ba35-17692deaa44e)

