CREATE DATABASE IF NOT EXISTS bigdaddy_burgers CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE bigdaddy_burgers;

CREATE TABLE Orders (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TableNumber INT NOT NULL,
    Observations LONGTEXT NULL,
    Total DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    CreatedAt DATETIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6)
) ENGINE=InnoDB CHARACTER SET utf8mb4;

CREATE TABLE OrderItems (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    OrderId INT NOT NULL,
    Name VARCHAR(200) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_OrderItems_Orders 
        FOREIGN KEY (OrderId) REFERENCES Orders(Id) 
        ON DELETE CASCADE
) ENGINE=InnoDB CHARACTER SET utf8mb4;

CREATE INDEX IX_Orders_TableNumber ON Orders(TableNumber);
CREATE INDEX IX_Orders_CreatedAt ON Orders(CreatedAt);

INSERT INTO Orders (TableNumber, Observations, Total) 
VALUES (7, 'Sem cebola e bem passado', 89.70);

INSERT INTO OrderItems (OrderId, Name, Quantity, Price) VALUES
(LAST_INSERT_ID(), 'Big Daddy Burger', 1, 39.90),
(LAST_INSERT_ID(), 'Coca-Cola 600ml', 1, 9.90),
(LAST_INSERT_ID(), 'Batata Frita Grande', 2, 19.95);