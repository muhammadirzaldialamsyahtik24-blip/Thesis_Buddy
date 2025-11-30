-- Database setup script for Thesis Buddy
-- Run this in phpMyAdmin or MySQL command line

DROP DATABASE IF EXISTS thesis_buddy;

CREATE DATABASE thesis_buddy;

USE thesis_buddy;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);