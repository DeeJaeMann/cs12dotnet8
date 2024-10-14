
/*
TimesTable(7);
TimesTable(number: 7, size: 20);
*/

ConfigureConsole();

decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "FR");
WriteLine($"You must pay {taxToPay:C} in tax.");
