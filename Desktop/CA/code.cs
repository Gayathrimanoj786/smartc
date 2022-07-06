using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;

public class Login
{
    string[] username = { "admin", "gayathri@gmail.com" };
    string[] password = { "Abc@1234", "Xyz@1234" };
    int[] type_of_user = { 1, 2 };

    public int authenticate(string user, string pass)
    {
        int i=0;
        for (i; i < 3; i++)
        {
            if (username[i].Equals(user))
            {
                if (password[i].Equals(pass))
                    return type_of_user[i];
            }
        }
        return -1;

    }

}
abstract public class Product
{
    public ArrayList product_name = new ArrayList();
    public ArrayList description = new ArrayList();
    public ArrayList product_id = new ArrayList();
    public ArrayList quantity = new ArrayList();
    public ArrayList cost = new ArrayList();
    int count = 0;
    public void heading()
    {
        Console.WriteLine("================================================================");
        Console.WriteLine("\tOnline Shopping Card\t\t");
        Console.WriteLine("================================================================");

    }
    public void add()
    {
        try
        {
            Console.Write("Enter Number of items to be added : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the Product Name, Cost of Signle Quantity, No. of Quantity, Product Description");
                product_name.Add(Console.ReadLine());
                cost.Add(Convert.ToDouble(Console.ReadLine()));
                quantity.Add(Convert.ToInt32(Console.ReadLine()));
                description.Add(Console.ReadLine());
                product_id.Add(++count);
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine("Input Format is Wrong");
        }

    }
    public void display()
    {
        Console.WriteLine("List of Items added in the Stock: ");
        for (int i = 0; i < product_name.Count; i++)
            Console.WriteLine(product_id[i] + "\t" + product_name[i] + "\t" + quantity[i] + " \t" + description[i] + "\t" + cost[i]);

    }
    public void search(int id1)
    {
        int i;
        for (i = 0; i < product_name.Count; i++)
        {
            if (Convert.ToInt32(product_id[i]) == id1)
            {
                Console.WriteLine("Search Result : ");
                Console.WriteLine("Product ID = " + product_id[i]);
                Console.WriteLine("Product Name = " + product_name[i]);
                Console.WriteLine("Quantity = " + quantity[i]);
                Console.WriteLine("Product Description = " + description[i]);
                Console.WriteLine("Cost of Single Quantity = " + cost[i]);
                break;
            }
        }
        if (i == product_id.Count)
            Console.WriteLine("Product id not found");

    }
    public void search(string name)
    {
        int i;
        for (i = 0; i < product_name.Count; i++)
        {
            if (Convert.ToString(product_name[i]).Equals(name))
            {
                Console.WriteLine("Search Result (Product name) : ");
                Console.WriteLine("Product ID = " + product_id[i]);
                Console.WriteLine("Product Name = " + product_name[i]);
                Console.WriteLine("Quantity = " + quantity[i]);
                Console.WriteLine("Product Description = " + description[i]);
                Console.WriteLine("Cost of Single Quantity = " + cost[i]);
                break;
            }
        }
        if (i == product_id.Count)
            Console.WriteLine("Product Name not found");

    }
    public void update()
    {
        try
        {
            Console.Write("\n1.Update the cost of the single quantity\n2.Update the Quantity\nEnter the choice:");
            int ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 1)
            {
                int i;
                Console.Write("Enter the ID to search:");
                int c = Convert.ToInt32(Console.ReadLine());
                for (i = 0; i < product_name.Count; i++)
                {
                    if (Convert.ToInt32(product_id[i]) == c)
                    {
                        Console.Write("Enter the update cost of the single quantity of the product:");
                        cost[i] = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                }
                if (i == product_name.Count)
                    Console.WriteLine("The product ID is not exist");
            }
            else if (ch == 2)
            {
                int i;
                Console.Write("Enter the ID to search:");
                int c = Convert.ToInt32(Console.ReadLine());
                for (i = 0; i < product_name.Count; i++)
                {
                    if (Convert.ToInt32(product_id[i]) == c)
                    {
                        Console.Write("Enter the number of quantity:");
                        int m = Convert.ToInt32(Console.ReadLine()) + Convert.ToInt32(quantity[i]);

                        quantity[i] = m;
                        break;
                    }
                }
                if (i == product_name.Count)
                    Console.WriteLine("The product ID is not exist");
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine("Format is not matched");
        }
    }
    public void delete()
    {
        int i;
        Console.Write("Enter the ID to search:");
        int c = Convert.ToInt32(Console.ReadLine());
        for (i = 0; i < product_name.Count; i++)
        {
            if (Convert.ToInt32(product_id[i]) == c)
            {
                product_name.RemoveAt(i);
                description.RemoveAt(i);
                product_id.RemoveAt(i);
                quantity.RemoveAt(i);
                cost.RemoveAt(i);
                display();
                break;
            }
        }
        if (i == product_name.Count)
            Console.WriteLine("Search record is not exist. So unable to print.");
    }
}



public class Cart_Product : Product
{
    public ArrayList cart_product_name = new ArrayList();
    public ArrayList cart_product_description = new ArrayList();
    public ArrayList cart_product_id = new ArrayList();
    public ArrayList cart_quantity = new ArrayList();
    public ArrayList cart_cost = new ArrayList();
    public ArrayList Individual_Total_price = new ArrayList();
    public double cart_total_price = 0;
    public void cart_add()
    {
        int i;
        bool f = true;
        try
        {
            while (f)
            {
                for (i = 0; i < product_name.Count; i++)
                {
                    Console.Write("Enter the ID to search:");
                    int c = Convert.ToInt32(Console.ReadLine());
                    if (cart_product_id.Contains(c))
                    {
                        Console.WriteLine("Already Exist. Kindly update the number of items if needed. Do you want to edit the number of items (Y/N)");
                        string m = Console.ReadLine();
                        if (m.Equals("Y"))
                            cart_update();
                        break;
                    }
                    else
                    {
                        for (i = 0; i < product_name.Count; i++)
                        {
                            if (Convert.ToInt32(product_id[i]) == c)
                            {
                                Console.Write("Enter the number of quantities needed :");
                                int m = Convert.ToInt32(Console.ReadLine());
                                if (m <= Convert.ToInt32(quantity[i]))
                                {
                                    cart_product_id.Add(product_id[i]);
                                    cart_product_name.Add(product_name[i]);
                                    cart_quantity.Add(m);
                                    cart_product_description.Add(description[i]);
                                    cart_cost.Add(cost[i]);
                                    Individual_Total_price.Add(m * Convert.ToDouble(cost[i]));
                                    cart_total_price = cart_total_price + (m * Convert.ToDouble(cost[i]));
                                    Console.Write("do you want to continue :(1/0)");
                                    int h = Convert.ToInt32(Console.ReadLine());
                                    if (h == 0)
                                        f = false;

                                }
                                else
                                {
                                    Console.WriteLine("Unable to add in to the cart");
                                    f = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine("Format is not matche");
        }
    }
    public void cart_update()
    {

        int i;
        try
        {
            Console.Write("Enter the ID to search:");
            int c = Convert.ToInt32(Console.ReadLine());
            for (i = 0; i < cart_product_name.Count; i++)
            {
                if (Convert.ToInt32(product_id[i]) == c)
                {
                    Console.Write("Enter the update number of quantity needed:");
                    int m = Convert.ToInt32(Console.ReadLine());
                    double h = (Convert.ToDouble(cart_quantity[i]) * Convert.ToDouble(cart_cost[i]));
                    cart_total_price = cart_total_price + (m * Convert.ToDouble(cart_cost[i]));
                    Individual_Total_price[i] = h + Convert.ToDouble(cart_cost[i]) * m;
                    display();
                    break;
                }
            }
            if (i == product_name.Count)
                Console.WriteLine("The product ID is not exist");
        }
        catch (FormatException e)
        {
            Console.WriteLine("For,at is not matched");
        }

    }

    public void cart_delete()
    {
        int i;
        try
        {
            Console.Write("Enter the ID to search:");
            int c = Convert.ToInt32(Console.ReadLine());
            for (i = 0; i < cart_product_name.Count; i++)
            {
                if (Convert.ToInt32(product_id[i]) == c)
                {
                    double h = Convert.ToDouble(cart_cost[i]) * Convert.ToDouble(cart_quantity[i]);
                    cart_total_price = cart_total_price - h;
                    cart_product_name.RemoveAt(i);
                    cart_product_description.RemoveAt(i);
                    cart_product_id.RemoveAt(i);
                    cart_quantity.RemoveAt(i);
                    cart_cost.RemoveAt(i);
                    Individual_Total_price.Remove(i);
                    display();
                    break;
                }
            }
            if (i == product_name.Count)
                Console.WriteLine("Search record is not exist. So unable to print.");
        }
        catch (FormatException e)
        {
            Console.WriteLine("Format is not Matched");
        }
    }
    public void cart_display()
    {

        Console.WriteLine("List of Items added in the Cart: ");
        if (cart_product_name.Count > 0)
        {
            for (int i = 0; i < cart_product_name.Count; i++)
                Console.WriteLine(cart_product_id[i] + "\t" + cart_product_name[i] + "\t" + cart_quantity[i] + " \t" + cart_product_description[i] + "\t" + cart_cost[i] + "\t" + Individual_Total_price[i]);
            Console.WriteLine("Total Price = " + cart_total_price);
        }
        else
            Console.WriteLine("cart is empty");
    }

}
public class Card_Payment : Cart_Product
{
    public string card_number = "1234567890123456";
    public string cvv = "371";
    public int verification(string user, string cvv1)
    {
        if (card_number.Equals(user) && cvv.Equals(cvv1))
            return 1;
        else
            return -1;
    }
}
sealed class Payment : Card_Payment
{
    public ArrayList pay_product_name = new ArrayList();
    public ArrayList pay_description = new ArrayList();
    public ArrayList pay_product_id = new ArrayList();
    public ArrayList pay_quantity = new ArrayList();
    public ArrayList pay_cost = new ArrayList();
    public ArrayList pay_individual_total_cost = new ArrayList();
    public ArrayList pay_id = new ArrayList();
    public ArrayList pay_total_cost = new ArrayList();
    int pay_count = 0;
    public int item_verification()
    {
        int c = 0;
        for (int i = 0; i < cart_product_name.Count; i++)
        {
            for (int j = 0; j < product_name.Count; j++)
            {
                if (Convert.ToInt32(product_id[j]) == Convert.ToInt32(cart_product_id[i]) && Convert.ToInt32(quantity[j]) >= Convert.ToInt32(cart_quantity[i]))
                    c++;
            }
        }
        if (c == cart_product_name.Count)
            return 1;
        else
            return -1;
    }
    public void payment_item(string user, string cvv)
    {
        int c = item_verification();
        if (c == 1)
        {
            if (cart_product_name.Count > 0)
            {
                if (verification(user, cvv) == 1)
                {
                    Console.WriteLine("Payment Successful");
                    pay_count++;

                    for (int i = 0; i < cart_product_name.Count; i++)
                    {
                        for (int j = 0; j < product_name.Count; j++)
                        {
                            if (Convert.ToInt32(product_id[i]) == Convert.ToInt32(cart_product_id[i]))
                            {
                                quantity[j] = Convert.ToInt32(quantity[j]) - Convert.ToInt32(cart_quantity[i]);
                                //break;
                            }
                        }
                        pay_product_name.Add(cart_product_name[i]);
                        pay_description.Add(cart_product_description[i]);
                        pay_product_id.Add(cart_product_id[i]);
                        pay_quantity.Add(cart_quantity[i]);
                        pay_cost.Add(cart_cost[i]);
                        pay_individual_total_cost.Add(Individual_Total_price[i]);
                        pay_id.Add(pay_count);
                        pay_total_cost.Add(cart_total_price);
                        cart_total_price = 0.0;
                    }
                    display_pay();
                    cart_product_name.Clear();
                    cart_product_description.Clear();
                    cart_product_id.Clear();
                    cart_quantity.Clear();
                    cart_cost.Clear();
                    Individual_Total_price.Clear();
                }
                else
                    Console.WriteLine("Invalid Credentials for payment");
            }
            else
                Console.WriteLine("No item in the cart");
        }
        else
            Console.WriteLine("Enough Stock is not Available to purchase. Sorry for the inconveience");
    }
    public void display_pay()
    {
        for (int i = 0; i < pay_product_name.Count; i++)
            Console.WriteLine(pay_id[i] + "  " + pay_product_name[i] + "  " + pay_quantity[i] + "  " + pay_total_cost[i]);

    }
}

class main
{
    public static void Main(string[] s)
    {
        int ch, ch11 = 1;
        bool logout = true;
        try
        {
            Payment p = new Payment();
            do
            {
                Console.Clear();
                p.heading();
                logout = true;
                Console.Write("Enter the user name : ");
                string user = Console.ReadLine();
                Console.Write("\n\nEnter the password : ");
                string pass = Console.ReadLine();
                Login l = new Login();
                int test_status = l.authenticate(user, pass);
                //Console.WriteLine("test Status = "+test_status);
                if (test_status == 1)
                {
                    do
                    {
                        Console.Clear();
                        p.heading();

                        Console.Write("\t\tMenu Choices:\n\n1.Product Relevant\n\n2.Cart Relevant activities\n\n3.Logout\n");
                        Console.WriteLine("================================================================");
                        Console.Write("Enter the choice:");

                        ch = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        p.heading();
                        if (ch == 1)
                        {
                            Console.WriteLine("\n================================================================\n");
                            Console.Write("\n1.Add New Product \n\n2.Display the number of product in stock\n\n3.Search the details of the product using ID\n\n4.Search the product using product name\n\n5.Update the product\n\n6.Delete the product");
                            Console.WriteLine("\n================================================================\n");
                            Console.Write("Enter the choice:");

                            ch = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            p.heading();
                            if (ch == 1)
                                p.add();
                            else if (ch == 2)
                                p.display();
                            else if (ch == 3)
                            {
                                Console.Write("Enter the ID to search:");
                                p.search(Convert.ToInt32(Console.ReadLine()));
                            }
                            else if (ch == 4)
                            {
                                Console.Write("Enter the product name to search:");
                                p.search(Console.ReadLine());
                            }
                            else if (ch == 5)
                                p.update();
                            else if (ch == 6)
                                p.delete();

                        }
                        else if (ch == 2)
                        {
                            Console.Clear();
                            p.heading();
                            Console.Write("\n1.Display the number of product in Cart\nEnter the choice:");
                            ch = Convert.ToInt32(Console.ReadLine());
                            if (ch == 1)
                                p.cart_add();
                            else if (ch == 2)
                                p.cart_display();
                            else if (ch == 3)
                                p.cart_update();
                            else if (ch == 4)
                                p.cart_delete();

                        }
                        else if (ch == 3)
                            logout = false;
                    }
                    while (logout == true);

                }
                else if (test_status == 2)
                {
                    do
                    {
                        Console.Clear();
                        p.heading();
                        Console.Write("\t\tMenu Choices:\n\n1.List of Product in Stock \n\n2.List of Products Selected\n\n3.Add new new product into the cart\n\n4.Update the product in the cart\n\n5.Delete the product in the cart\n\n6.Payment\n\n7.Display \n\n8.Logout");
                        Console.WriteLine("\n======================================================================================");
                        Console.WriteLine("\nEnter the chocie:");
                        ch = Convert.ToInt32(Console.ReadLine());
                        if (ch == 1)
                            p.display();
                        else if (ch == 2)
                            p.cart_display();
                        else if (ch == 3)
                            p.cart_add();
                        else if (ch == 4)
                            p.cart_update();
                        else if (ch == 5)
                            p.cart_delete();
                        else if (ch == 6)
                        {
                            Console.WriteLine("Enter card_number and CVV");
                            p.payment_item(Console.ReadLine(), Console.ReadLine());
                        }
                        else if (ch == 7)
                            p.display_pay();
                        else if (ch == 8)
                            logout = false;
                    } while (logout == true);

                    Console.Write("Do you want to continue (1/0)");
                    ch11 = Convert.ToInt32(Console.ReadLine());
                }
                else
                    Console.WriteLine("User name and passoword is not exist. Plese Try again");

            } while (ch11 == 1);

        }
        catch (FormatException e)
        {
            Console.WriteLine("Format is not MAtched");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("Index exceeds out of range");
        }
        catch (InsufficientMemoryException e)
        {
            Console.WriteLine("Insuffcicient Memory. Unable to allocate");
        }
    }

}
