CREATE TABLE Seller
(
	SellerID INT NOT NULL,
	SellerName NVARCHAR(50) NOT NULL
	CONSTRAINT [PK_Seller] PRIMARY KEY (SellerID)
);

INSERT INTO Seller VALUES
(1, 'Gayle Hardy'),
(2, 'Lyle Banks'),
(3, 'Pearl Greene');

CREATE TABLE Buyer 
(
	BuyerID INT NOT NULL,
	BuyerName NVARCHAR(50) NOT NULL
	CONSTRAINT [PK_Buyer] Primary Key (BuyerID)
);

INSERT INTO Buyer VALUES
(1, 'Jane Stone'),
(2, 'Tom McMasters'),
(3, 'Otto Vanderwall');

CREATE TABLE Item
(
	ItemID INT NOT NULL,
	SellerID  INT NOT NULL,
	ItemName NVARCHAR(128) NOT NULL,
	ItemDescription NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_Item] PRIMARY KEY (ItemID),
	CONSTRAINT [FK_Item] FOREIGN KEY (SellerID)
	REFERENCES Seller (SellerID)
);

INSERT INTO Item VALUES
(1001, 3, 'Abraham Lincoln''s Hammer', 'A bench mallet fashioned from a borken rail splitting maul in 1829 and owned by Abraham Lincoln'),
(1002, 1, 'Albert Einsten''s Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927'),
(1003, 2, 'Bob Dylan''s Love Poems', 'Five versions of an original unpublished, handwritten, love poem by Bob Dylan');


CREATE TABLE Bid
(
	ItemID INT NOT NULL,
	BuyerID INT NOT NULL,
	Price MONEY NOT NULL,
	PurchaseDate DateTime,
	CONSTRAINT [FK1_Bid] FOREIGN KEY (ItemID)
	REFERENCES Item (ItemID),
	CONSTRAINT [FK2_Bid] FOREIGN KEY (BuyerID)
	REFERENCES Buyer (BuyerID)
);

INSERT INTO Bid VALUES
(1001, 3, CAST('$250,000' AS MONEY), '12/04/2017 09:04:22'),
(1003, 1, CAST('$95000' AS MONEY), '12/04/2017 08:44:03');