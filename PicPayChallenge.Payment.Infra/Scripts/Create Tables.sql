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

CREATE TABLE IF NOT EXISTS PixPayment(
	PixPaymentId INT AUTO_INCREMENT NOT NULL,
	PRIMARY KEY (PixPaymentId)
);

CREATE TABLE IF NOT EXISTS CardPayment(
	CardPaymentId INT AUTO_INCREMENT NOT NULL,
    ChargeId VARCHAR(41) NOT NULL,
    CardPaymentMethod INT NOT NULL,
    Amount DECIMAL NOT NULL,
    Installments INT NOT NULL,
    Brand VARCHAR(20) NOT NULL,
    LastDigits VARCHAR(4) NOT NULL,
    AuthorizationCode INT NOT NULL,
    NsuHost VARCHAR(20) NOT NULL,
	PRIMARY KEY (CardPaymentId)
);

CREATE TABLE IF NOT EXISTS BoletoPayment(
	BoletoPaymentId INT AUTO_INCREMENT NOT NULL,
	ChargeId VARCHAR(41) NOT NULL,
	BoletoPagSeguroId VARCHAR(255) NOT NULL,
    Barcode VARCHAR(255) NOT NULL,
    Status INT NOT NULL,
    DueDate DATETIME NOT NULL,
    CreatedAt DATETIME NOT NULL,
    PayedAt DATETIME NOT NULL,
	PRIMARY KEY (BoletoPaymentId)
);

CREATE TABLE IF NOT EXISTS Payment(
	PaymentId INT AUTO_INCREMENT NOT NULL,
	PaymentMethod INT NOT NULL,
    CardPaymentId INT NULL,
    PixPaymentId INT NULL,
    BoletoPaymentId INT NULL,
	PRIMARY KEY (PaymentId),
	FOREIGN KEY (CardPaymentId) REFERENCES CardPayment(CardPaymentId),
	FOREIGN KEY (PixPaymentId) REFERENCES PixPayment(PixPaymentId),
	FOREIGN KEY (BoletoPaymentId) REFERENCES BoletoPayment(BoletoPaymentId)
);

CREATE TABLE IF NOT EXISTS Transaction(
	TransactionId INT AUTO_INCREMENT NOT NULL, 
    SenderId INT NOT NULL,
    RecieverId INT NOT NULL,
    PaymentId INT NOT NULL,
    Amount DECIMAL(12, 2) NOT NULL,
	TransactionDate DATETIME NOT NULL,
    PRIMARY KEY (TransactionId),
	FOREIGN KEY (SenderId) REFERENCES User(UserId),
	FOREIGN KEY (RecieverId) REFERENCES User(UserId),
	FOREIGN KEY (PaymentId) REFERENCES Payment(PaymentId)
);