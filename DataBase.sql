CREATE DATABASE task3_db;
USE task3_db;

CREATE TABLE Customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    age INT CHECK (age >= 18),
    country VARCHAR(50) DEFAULT 'Kazakhstan'
);

CREATE TABLE Products (
    product_id INT AUTO_INCREMENT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    price DECIMAL(10,2) NOT NULL CHECK (price > 0),
    stock INT NOT NULL DEFAULT 0,
    category VARCHAR(50)
);

CREATE TABLE Orders (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    order_date DATE DEFAULT (CURRENT_DATE),
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

ALTER TABLE Customers
ADD phone VARCHAR(20);

ALTER TABLE Products
MODIFY category VARCHAR(100) NOT NULL;

ALTER TABLE Orders
ADD CONSTRAINT unique_order UNIQUE (customer_id, product_id, order_date);

INSERT INTO Customers (full_name, email, age, country, phone) VALUES
('Ivan Petrov', 'ivan@example.com', 21, 'Kazakhstan', '+77010000001'),
('Anna Sidorova', 'anna@example.com', 22, 'Russia', '+77010000002'),
('Sergey Ivanov', 'sergey@example.com', 20, 'Kazakhstan', '+77010000003'),
('Maria Kozlova', 'maria@example.com', 19, 'Belarus', '+77010000004'),
('Daniyar Akhmetov', 'daniyar@example.com', 23, 'Kazakhstan', '+77010000005');

INSERT INTO Products (product_name, price, stock, category) VALUES
('Laptop', 350000.00, 10, 'Electronics'),
('Mouse', 5000.00, 50, 'Accessories'),
('Keyboard', 12000.00, 30, 'Accessories'),
('Monitor', 70000.00, 15, 'Electronics'),
('Headphones', 18000.00, 25, 'Audio');

INSERT INTO Orders (customer_id, product_id, quantity, order_date) VALUES
(1, 1, 1, '2026-03-10'),
(2, 2, 2, '2026-03-11'),
(3, 3, 1, '2026-03-12'),
(4, 4, 1, '2026-03-13'),
(5, 5, 3, '2026-03-14');

SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM Orders;

SELECT 
    Orders.order_id,
    Customers.full_name,
    Products.product_name,
    Orders.quantity,
    Orders.order_date
FROM Orders
JOIN Customers ON Orders.customer_id = Customers.customer_id
JOIN Products ON Orders.product_id = Products.product_id;