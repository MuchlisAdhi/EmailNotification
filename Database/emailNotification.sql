--
-- PostgreSQL database dump
--

-- Dumped from database version 16.9
-- Dumped by pg_dump version 16.9

-- Started on 2025-10-08 16:35:46

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 6 (class 2615 OID 232511)
-- Name: Transaction; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA "Transaction";


ALTER SCHEMA "Transaction" OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 232512)
-- Name: tbtemaillog; Type: TABLE; Schema: Transaction; Owner: postgres
--

CREATE TABLE "Transaction".tbtemaillog (
    "Key" uuid NOT NULL,
    "SenderEmail" character varying(255) NOT NULL,
    "SenderName" character varying(100) NOT NULL,
    "RecipientEmail" character varying(255) NOT NULL,
    "ReceiverName" character varying(100) NOT NULL,
    "Subject" character varying(255) NOT NULL,
    "Body" text NOT NULL,
    "SentAt" timestamp with time zone DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Asia/Jakarta'::text) NOT NULL
);


ALTER TABLE "Transaction".tbtemaillog OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 232506)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 4888 (class 0 OID 232512)
-- Dependencies: 217
-- Data for Name: tbtemaillog; Type: TABLE DATA; Schema: Transaction; Owner: postgres
--

COPY "Transaction".tbtemaillog ("Key", "SenderEmail", "SenderName", "RecipientEmail", "ReceiverName", "Subject", "Body", "SentAt") FROM stdin;
2c0133ef-91ca-45ee-b1cf-08566b5892a7	developer.test1008@outlook.com	Muchlis Adhi	developer.sidoagung@gmail.com	Wiratama	test notif email	\r\n\r\n<!DOCTYPE html>\r\n<html lang="en">\r\n<head>\r\n    <meta charset="UTF-8">\r\n    <meta name="viewport" content="width=device-width, initial-scale=1.0">\r\n    <title>test notif email</title>\r\n    <style>\r\n        body { font-family: Arial, sans-serif; line-height: 1.6; color: #333; }\r\n        .container { max-width: 600px; margin: 20px auto; padding: 20px; border: 1px solid #ddd; border-radius: 5px; }\r\n        .header { background-color: #f4f4f4; padding: 10px; text-align: center; }\r\n        .footer { margin-top: 20px; font-size: 0.8em; text-align: center; color: #777; }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class="container">\r\n        <div class="header">\r\n            <h2>Notifikasi dari Test Email</h2>\r\n        </div>\r\n        <div class="content">\r\n            <p>Halo, Wiratama</p>\r\n            <p></p>\r\n            <p>Terima kasih.</p>\r\n        </div>\r\n        <div class="footer">\r\n            <p>&copy; 2025 Test Email.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>	2025-10-08 12:06:19.937+07
\.


--
-- TOC entry 4887 (class 0 OID 232506)
-- Dependencies: 216
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20251008033926_InitialCreate	9.0.9
\.


--
-- TOC entry 4743 (class 2606 OID 232519)
-- Name: tbtemaillog PK_tbtemaillog; Type: CONSTRAINT; Schema: Transaction; Owner: postgres
--

ALTER TABLE ONLY "Transaction".tbtemaillog
    ADD CONSTRAINT "PK_tbtemaillog" PRIMARY KEY ("Key");


--
-- TOC entry 4741 (class 2606 OID 232510)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


-- Completed on 2025-10-08 16:35:47

--
-- PostgreSQL database dump complete
--

