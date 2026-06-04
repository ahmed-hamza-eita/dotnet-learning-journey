/*

#region Encapsulate What Varies
Console.WriteLine("Encapsulate What Varies Example:");

//Pizza Example
Pizza pizza = Pizza.RequestOrder(ConstPizza.CheesePizza);
Console.WriteLine(pizza);


//Payment Example
IPaymentMethod paymentMethod = new VisaPayment();
PaymentService paymentService = new PaymentService(paymentMethod);
paymentService.Pay(1000);
#endregion


#region Composition _ Inheritance
Console.WriteLine("Composition and Inheritance Example:");

INotificationSender emailSender = new EmailSender();
NotificationService notificationService = new NotificationService(emailSender);
notificationService.NotifyUser("Hello, this is a notification message!");

#endregion


#region  Single Responsibility


#endregion


#region   Open/Closed Principle
DiscountService discountService = new DiscountService(new GoldDiscount());
Console.WriteLine(discountService.CalculateDiscount(5000));
#endregion


#region  Liskov Substitution Principle

INotificationSender emailSender = new EmailSender();
INotificationSender smsSender = new SMSSender();

NotificationService notificationServiceEmail = new NotificationService(emailSender);
NotificationService notificationServiceSms = new NotificationService(smsSender);

notificationServiceEmail.NotifyUser("Hello, this is a notification message!");
notificationServiceSms.NotifyUser("Hello, this is a notification message!");


#endregion


*/



#region  Dependency Injection Principle
Checkout checkout = new Checkout(new Visa());
checkout.CompleteOrder();
#endregion