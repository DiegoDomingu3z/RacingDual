-- Active: 1664942208484@@SG-diego-dom-54277.servers.mongodirector.com@3306

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS posts(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        likes INT DEFAULT 0,
        shares INT DEFAULT 0,
        description TEXT NOT NULL,
        img TEXT,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS postLikes(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        accountId VARCHAR(255) NOT NULL,
        postId int NOT NULL,
        FOREIGN KEY(accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY(postId) REFERENCES posts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS postComments(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        body TEXT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        postId INT NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (postId) REFERENCES posts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS simRigs(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        simType ENUM('GT', 'F1', 'Flight', 'Cruiser') NOT NULL,
        console VARCHAR(255) NOT NULL,
        Chassis VARCHAR(255),
        monitorStand VARCHAR(255),
        wheelBase VARCHAR(255) NOT NULL,
        steeringWheel VARCHAR(255) NOT NULL,
        pedal VARCHAR(255) NOT NULL,
        software TEXT,
        extras TEXT,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS simRigLikes(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        accountId VARCHAR(255) NOT NULL,
        simRigId int NOT NULL,
        FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (simRigId) REFERENCES simRigs(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS chatRooms(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        isAccepted TINYINT DEFAULT 0,
        accountId VARCHAR(255) NOT NULL,
        profileId VARCHAR(255) NOT NULL,
        FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS chats(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        body TEXT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        userProfileId VARCHAR(255) NOT NULL,
        chatRoomId INT NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (chatRoomId) REFERENCES chatRooms(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';