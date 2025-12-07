-- Skrip setup database untuk Thesis Buddy
--  phpMyAdmin atau MySQL command line (CLI)

DROP DATABASE IF EXISTS thesis_buddy;

CREATE DATABASE thesis_buddy;

USE thesis_buddy;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(20) NOT NULL DEFAULT 'user'
) ENGINE=InnoDB;

-- Admin default account
-- user : admin
-- password : admin123
INSERT INTO users (username, password, role)
VALUES (
    'admin',
    TO_BASE64(SHA2(CONCAT('admin123', 'ThesisBuddySalt'), 256)),
    'admin'
)
ON DUPLICATE KEY UPDATE role = VALUES(role);

-- Tabel riwayat konsultasi
CREATE TABLE IF NOT EXISTS consultations (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255),
    timestamp DATETIME,
    answers TEXT,
    recommendations TEXT
) ENGINE=InnoDB;

-- Tabel pertanyaan untuk pertanyaan dinamis/adaptif
CREATE TABLE IF NOT EXISTS questions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    qkey VARCHAR(255),
    prompt TEXT,
    qtype VARCHAR(50),
    options TEXT,
    step INT,
    active TINYINT(1) DEFAULT 1,
    category VARCHAR(20),
    rule_code VARCHAR(50),
    cf_value DOUBLE
) ENGINE=InnoDB;

-- Data pertanyaan McClelland akan diimport otomatis dari assets/mcclelland_questionnaire.txt saat aplikasi dijalankan.
