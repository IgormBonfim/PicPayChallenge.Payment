CREATE SCHEMA IF NOT EXISTS PicPayChallengePayment;

USE PicPayChallengePayment;

CREATE TABLE IF NOT EXISTS Wallet(
	WalletId INT NOT NULL,
    Balance DECIMAL(12,2) NOT NULL,
    PRIMARY KEY (WalletId)
);

CREATE TABLE IF NOT EXISTS User(
	UserId INT NOT NULL,
    WalletId INT UNIQUE NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    DocumentNumber VARCHAR(14) UNIQUE NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    UserType INT NOT NULL,
    PRIMARY KEY (UserId),
    FOREIGN KEY (WalletId) REFERENCES Wallet(WalletId)
);

CREATE TABLE IF NOT EXISTS Transaction(
	TransactionId INT AUTO_INCREMENT NOT NULL, 
    SenderId INT NOT NULL,
    RecieverId INT NOT NULL,
    Amount DECIMAL(12, 2) NOT NULL,
    PaymentMethod INT NOT NULL,
	TransactionDate DATETIME NOT NULL,
    PRIMARY KEY (TransactionId),
	FOREIGN KEY (SenderId) REFERENCES User(UserId),
	FOREIGN KEY (RecieverId) REFERENCES User(UserId)
);