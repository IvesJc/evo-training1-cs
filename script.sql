﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Batalhas" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "Descricao" text NOT NULL,
    "DtInicio" timestamp with time zone NOT NULL,
    "DtFim" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Batalhas" PRIMARY KEY ("Id")
);

CREATE TABLE "Herois" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "BatalhaId" integer NOT NULL,
    CONSTRAINT "PK_Herois" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Herois_Batalhas_BatalhaId" FOREIGN KEY ("BatalhaId") REFERENCES "Batalhas" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Armas" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "HeroiId" integer NOT NULL,
    CONSTRAINT "PK_Armas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Armas_Herois_HeroiId" FOREIGN KEY ("HeroiId") REFERENCES "Herois" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Armas_HeroiId" ON "Armas" ("HeroiId");

CREATE INDEX "IX_Herois_BatalhaId" ON "Herois" ("BatalhaId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240912151009_Initial', '8.0.8');

COMMIT;

START TRANSACTION;

ALTER TABLE "Herois" DROP CONSTRAINT "FK_Herois_Batalhas_BatalhaId";

DROP INDEX "IX_Herois_BatalhaId";

ALTER TABLE "Herois" DROP COLUMN "BatalhaId";

CREATE TABLE "HeroiBatalhas" (
    "HeroId" integer NOT NULL,
    "BatalhaId" integer NOT NULL,
    "HeroiId" integer NOT NULL,
    CONSTRAINT "PK_HeroiBatalhas" PRIMARY KEY ("BatalhaId", "HeroId"),
    CONSTRAINT "FK_HeroiBatalhas_Batalhas_BatalhaId" FOREIGN KEY ("BatalhaId") REFERENCES "Batalhas" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_HeroiBatalhas_Herois_HeroiId" FOREIGN KEY ("HeroiId") REFERENCES "Herois" ("Id") ON DELETE CASCADE
);

CREATE TABLE "IdentidadeSecretas" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "NomeReal" text NOT NULL,
    "HeroiId" integer NOT NULL,
    CONSTRAINT "PK_IdentidadeSecretas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_IdentidadeSecretas_Herois_HeroiId" FOREIGN KEY ("HeroiId") REFERENCES "Herois" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_HeroiBatalhas_HeroiId" ON "HeroiBatalhas" ("HeroiId");

CREATE UNIQUE INDEX "IX_IdentidadeSecretas_HeroiId" ON "IdentidadeSecretas" ("HeroiId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240912165650_HeroisBatalhas_Identidade', '8.0.8');

COMMIT;

