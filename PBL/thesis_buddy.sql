-- Skrip setup database untuk Thesis Buddy
--  phpMyAdmin atau MySQL command line (CLI)

DROP DATABASE IF EXISTS thesis_buddy;

CREATE DATABASE thesis_buddy;

USE thesis_buddy;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
) ENGINE=InnoDB;

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
    active TINYINT(1) DEFAULT 1
) ENGINE=InnoDB;

-- Seed contoh pertanyaan (dikelompokkan per langkah)
-- Langkah 1: profil & minat
INSERT INTO questions (qkey, prompt, qtype, options, step, active) VALUES
('prodi', 'Program Studi (contoh: TI, TMJ, TMD):', 'select', 'TI,TMJ,TMD,Lainnya', 1, 1),
('ipk', 'Berapa IPK terakhir Anda?', 'number', NULL, 1, 1),
('interests', 'Masukkan skor minat (format: AI/ML:0.8,Data Science:0.6,...):', 'kvlist', NULL, 1, 1);

-- Langkah 2: kompetensi & preferensi
INSERT INTO questions (qkey, prompt, qtype, options, step, active) VALUES
('core_course', 'Mata kuliah inti apa yang paling Anda kuasai?', 'text', NULL, 2, 1),
('weak_course', 'Mata kuliah apa yang paling Anda kurang kuasai?', 'text', NULL, 2, 1),
('problem_solving', 'Tingkat kemampuan problem solving Anda (0.0–1.0):', 'select', '0.0,0.2,0.4,0.6,0.8,1.0', 2, 1);

-- Langkah 3: sumber daya & skill
INSERT INTO questions (qkey, prompt, qtype, options, step, active) VALUES
('devices', 'Perangkat yang Anda miliki (contoh: ESP32, RPi, GPU, Kamera):', 'text', NULL, 3, 1),
('duration', 'Berapa durasi pengerjaan maksimal Anda (bulan)?', 'number', NULL, 3, 1),
('skills', 'Masukkan skor skill (format: Python:0.8,Java:0.4,...):', 'kvlist', NULL, 3, 1);

-- Pertanyaan contoh tambahan (metode/output)
INSERT INTO questions (qkey, prompt, qtype, options, step, active) VALUES
('methods', 'Metode penelitian yang Anda pilih (Experimental,R&D,Case Study,Simulation):', 'select', 'Experimental,R&D,Case Study,Simulation', 4, 1),
('output_type', 'Output yang diinginkan (Aplikasi,Game,IoT Device,Model AI):', 'select', 'Aplikasi,Game,IoT Device,Model AI,Other', 4, 1);

-- dah abis :v
