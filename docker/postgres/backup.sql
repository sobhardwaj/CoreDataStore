--
-- PostgreSQL database dump
--

-- Dumped from database version 9.5.3
-- Dumped by pg_dump version 9.5.3

-- Started on 2016-07-03 12:52:42

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 185 (class 1259 OID 16412)
-- Name: LPCReport; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "LPCReport" (
    "Id" integer NOT NULL,
    "Architect" character varying,
    "Borough" character varying,
    "DateDesignated" timestamp without time zone NOT NULL,
    "LPCId" character varying,
    "LPNumber" character varying,
    "Name" text,
    "ObjectType" character varying,
    "PhotoStatus" boolean NOT NULL,
    "PhotoURL" character varying,
    "Street" text,
    "Style" character varying
);


ALTER TABLE "LPCReport" OWNER TO postgres;

--
-- TOC entry 184 (class 1259 OID 16410)
-- Name: LPCReport_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "LPCReport_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "LPCReport_Id_seq" OWNER TO postgres;

--
-- TOC entry 2114 (class 0 OID 0)
-- Dependencies: 184
-- Name: LPCReport_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "LPCReport_Id_seq" OWNED BY "LPCReport"."Id";


--
-- TOC entry 183 (class 1259 OID 16401)
-- Name: Landmark; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "Landmark" (
    "Id" integer NOT NULL,
    "BBL" bigint NOT NULL,
    "BIN_NUMBER" bigint NOT NULL,
    "BLOCK" integer NOT NULL,
    "BOUNDARIES" text,
    "BoroughID" text,
    "CALEN_DATE" text,
    "COUNT_BLDG" boolean NOT NULL,
    "DESIG_ADDR" text,
    "DESIG_DATE" text,
    "HIST_DISTR" text,
    "LAST_ACTIO" text,
    "LM_NAME" text,
    "LM_TYPE" text,
    "LOT" integer NOT NULL,
    "LP_NUMBER" text,
    "MOST_CURRE" boolean NOT NULL,
    "NON_BLDG" text,
    "OTHER_HEAR" text,
    "PLUTO_ADDR" text,
    "PUBLIC_HEA" text,
    "SECND_BLDG" boolean NOT NULL,
    "STATUS" text,
    "STATUS_NOT" text,
    "VACANT_LOT" boolean NOT NULL
);


ALTER TABLE "Landmark" OWNER TO postgres;

--
-- TOC entry 182 (class 1259 OID 16399)
-- Name: Landmark_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "Landmark_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Landmark_Id_seq" OWNER TO postgres;

--
-- TOC entry 2115 (class 0 OID 0)
-- Dependencies: 182
-- Name: Landmark_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "Landmark_Id_seq" OWNED BY "Landmark"."Id";


--
-- TOC entry 1991 (class 2604 OID 16415)
-- Name: Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "LPCReport" ALTER COLUMN "Id" SET DEFAULT nextval('"LPCReport_Id_seq"'::regclass);


--
-- TOC entry 1990 (class 2604 OID 16404)
-- Name: Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Landmark" ALTER COLUMN "Id" SET DEFAULT nextval('"Landmark_Id_seq"'::regclass);


--
-- TOC entry 1995 (class 2606 OID 16420)
-- Name: PK_LPCReport; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "LPCReport"
    ADD CONSTRAINT "PK_LPCReport" PRIMARY KEY ("Id");


--
-- TOC entry 1993 (class 2606 OID 16409)
-- Name: PK_Landmark; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Landmark"
    ADD CONSTRAINT "PK_Landmark" PRIMARY KEY ("Id");


-- Completed on 2016-07-03 12:52:42

--
-- PostgreSQL database dump complete
--

