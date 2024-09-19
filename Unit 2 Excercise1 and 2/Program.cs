
//class InventoryItem
//{
//    public string ItemName;
//    public int ItemQuantity; 

//    public InventoryItem(string itemName, int initialQuantity)
//    {
//        ItemName = itemName;
//        ItemQuantity = initialQuantity;
//    }

//    // Add items to inventory
//    public void AddItem(int quantity)
//    {
//        if (quantity > 0)
//        {
//            ItemQuantity += quantity;
//            Console.WriteLine($"{quantity} {ItemName}(s) added to the inventory. Total: {ItemQuantity}");
//        }
//        else
//        {
//            Console.WriteLine("Quantity to add must be positive.");
//        }
//    }

//    // Remove items from inventory
//    public void RemoveItem(int quantity)
//    {
//        if (quantity > 0 && quantity <= ItemQuantity)
//        {
//            ItemQuantity -= quantity;
//            Console.WriteLine($"{quantity} {ItemName}(s) removed from the inventory. Remaining: {ItemQuantity}");
//        }
//        else if (quantity > ItemQuantity)
//        {
//            Console.WriteLine("Error: Not enough items to remove.");
//        }
//        else
//        {
//            Console.WriteLine("Quantity to remove must be positive.");
//        }
//    }

//    // Get item details
//    public void GetItemDetails()
//    {
//        Console.WriteLine($"Item: {ItemName}, Quantity: {ItemQuantity}");
//    }
//}

//// Inventory Class to manage inventory items
//class Inventory
//{
//    private List<InventoryItem> items = new List<InventoryItem>();

//    // Add an item to the inventory
//    public void AddItem(string itemName, int quantity)
//    {
//        InventoryItem item = GetItem(itemName);
//        if (item == null)
//        {
//            item = new InventoryItem(itemName, quantity);
//            items.Add(item);
//            Console.WriteLine($"New item added: {itemName} with quantity {quantity}");
//        }
//        else
//        {
//            item.AddItem(quantity);
//        }
//    }

//    // Remove an item from the inventory
//    public void RemoveItem(string itemName, int quantity)
//    {
//        InventoryItem item = GetItem(itemName);
//        if (item != null)
//        {
//            item.RemoveItem(quantity);
//            if (item.ItemQuantity == 0)
//            {
//                items.Remove(item);
//                Console.WriteLine($"{itemName} has been removed from inventory as the quantity reached zero.");
//            }
//        }
//        else
//        {
//            Console.WriteLine($"Error: {itemName} not found in inventory.");
//        }
//    }

//    // Get an item from the inventory
//    public InventoryItem GetItem(string itemName)
//    {
//        return items.Find(i => i.ItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));
//    }

//    // Print all items in the inventory
//    public void PrintInventory()
//    {
//        if (items.Count == 0)
//        {
//            Console.WriteLine("The inventory is empty.");
//        }
//        else
//        {
//            Console.WriteLine("\nCurrent Inventory:");
//            foreach (var item in items)
//            {
//                item.GetItemDetails();
//            }
//        }
//    }
//}

//// Main Program with Menu
//class Program
//{
//    static Inventory inventory = new Inventory();

//    static void Main(string[] args)
//    {
//        bool exit = false;
//        while (!exit)
//        {
//            try
//            {
//                Console.WriteLine("\n--- Inventory System ---");
//                Console.WriteLine("1. Add Item");
//                Console.WriteLine("2. Remove Item");
//                Console.WriteLine("3. Get Item Details");
//                Console.WriteLine("4. Print Inventory");
//                Console.WriteLine("5. Exit");
//                Console.Write("Select an option: ");
//                int choice = int.Parse(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        AddItem();
//                        break;
//                    case 2:
//                        RemoveItem();
//                        break;
//                    case 3:
//                        GetItemDetails();
//                        break;
//                    case 4:
//                        inventory.PrintInventory();
//                        break;
//                    case 5:
//                        exit = true;
//                        break;
//                    default:
//                        Console.WriteLine("Invalid option. Please try again.");
//                        break;
//                }
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Invalid input format. Please enter valid data.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred: {ex.Message}");
//            }
//        }
//    }

//    // Method to add an item to inventory
//    static void AddItem()
//    {
//        try
//        {
//            Console.Write("Enter Item Name: ");
//            string itemName = Console.ReadLine();
//            Console.Write("Enter Quantity to Add: ");
//            int quantity = int.Parse(Console.ReadLine());

//            if (quantity <= 0)
//            {
//                throw new ArgumentException("Quantity must be greater than zero.");
//            }

//            inventory.AddItem(itemName, quantity);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error adding item: {ex.Message}");
//        }
//    }

//    // Method to remove an item from inventory
//    static void RemoveItem()
//    {
//        try
//        {
//            Console.Write("Enter Item Name: ");
//            string itemName = Console.ReadLine();
//            Console.Write("Enter Quantity to Remove: ");
//            int quantity = int.Parse(Console.ReadLine());

//            if (quantity <= 0)
//            {
//                throw new ArgumentException("Quantity must be greater than zero.");
//            }

//            inventory.RemoveItem(itemName, quantity);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error removing item: {ex.Message}");
//        }
//    }

//    // Method to get details of a specific item
//    static void GetItemDetails()
//    {
//        Console.Write("Enter Item Name: ");
//        string itemName = Console.ReadLine();
//        InventoryItem item = inventory.GetItem(itemName);

//        if (item != null)
//        {
//            item.GetItemDetails();
//        }
//        else
//        {
//            Console.WriteLine($"Item {itemName} not found in the inventory.");
//        }
//    }
//}
