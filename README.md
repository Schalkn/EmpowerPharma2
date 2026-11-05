# EmpowerPharma

EmpowerPharma is an ASP.NET/C# prototype for managing digital prescription workflows.

The project explores how a healthcare practitioner could create and manage prescriptions digitally, including patient and product selection, verification and generation of prescription documents.

This repository is retained as a technical portfolio project demonstrating hands-on development with ASP.NET Web Forms, C# and the .NET Framework.

---

## Overview

The application provides a browser-based prescription workflow with functionality including:

- practitioner-facing prescription creation
- patient management
- product selection
- prescription item management
- OTP-based verification
- PDF prescription generation
- responsive web interface components

The project combines application workflow, server-side processing and document generation in a traditional ASP.NET architecture.

---

## Technology Stack

The application uses:

- C#
- ASP.NET Web Forms
- .NET Framework 4.8.1
- HTML / CSS
- JavaScript
- Bootstrap
- jQuery
- Ajax Control Toolkit
- iTextSharp
- Newtonsoft.Json
- IIS / IIS Express

---

## Key Features

### Prescription Creation

The application provides a structured workflow for building a prescription, combining practitioner, patient and product information.

### Patient Management

Patient details can be added and associated with the prescription workflow.

### Product Selection

Products can be selected and added to prescriptions together with quantity and descriptive information.

### OTP Verification

A six-digit OTP workflow is used as part of the prescription confirmation process.

The current implementation demonstrates the verification flow and provides a placeholder for integration with an external SMS service.

### PDF Generation

Completed prescription information can be rendered into PDF documents using iTextSharp.

The generated document can include:

- practitioner information
- selected products
- quantities
- descriptions
- patient information

---

## Application Architecture

At a high level:

```text
Browser
   |
   v
ASP.NET Web Forms UI
   |
   +---- Prescription Workflow
   |
   +---- Patient Management
   |
   +---- Product Management
   |
   +---- OTP Verification
   |
   +---- PDF Generation
   |
   v
C# Application Logic
```

The application uses the traditional ASP.NET Web Forms model, with `.aspx` pages backed by C# code-behind classes.

---

## Project Structure

The solution includes:

- ASP.NET Web Forms pages
- C# code-behind
- reusable master pages
- responsive/mobile presentation support
- client-side scripts
- Bootstrap styling
- server-side workflow logic
- document-generation functionality

The project targets the .NET Framework and is structured for execution through IIS or IIS Express.

---

## What This Project Demonstrates

The project demonstrates practical experience with:

- C# development
- ASP.NET Web Forms
- server-side web application development
- stateful web workflows
- user-input processing
- OTP-style verification flows
- PDF/document generation
- responsive web interfaces
- third-party library integration
- application architecture
- healthcare-oriented workflow prototyping

---

## Development Approach

This project was developed as an application prototype with the assistance of AI-based development tooling.

AI tools were used to accelerate parts of the implementation while the application requirements, workflow, architecture and resulting solution remained subject to human direction and review.

The project reflects practical experimentation with AI-assisted software development alongside traditional C#/.NET development.

---

## Relationship to Prescriber Sync & Sign

EmpowerPharma and the separate **Prescriber Sync & Sign** project explore a similar prescription-management problem using different technology stacks.

EmpowerPharma uses a traditional Microsoft web stack:

- ASP.NET Web Forms
- C#
- .NET Framework

Prescriber Sync & Sign explores the same general domain using a more modern front-end stack based on:

- React
- TypeScript
- Vite

Together, the two projects demonstrate the ability to approach the same business problem using different technology architectures and development paradigms.

---

## Prototype Status

This is a technical prototype rather than a production healthcare system.

A production implementation would require additional work around areas such as:

- authentication and identity
- persistent data storage
- encryption and secrets management
- privacy and regulatory compliance
- audit logging
- secure SMS/OTP integration
- role-based access control
- production-grade validation and error handling

---

## About Me

I am a technology leader, solution architect and developer with experience spanning software development, cloud, APIs, databases, product management, cybersecurity and enterprise customer technology.

My technical background includes:

- C# / .NET
- ASP.NET
- SQL Server
- PostgreSQL
- REST and GraphQL APIs
- AWS
- Microsoft Azure
- relational databases
- solution and integration architecture

I continue to work hands-on with software, databases and APIs alongside senior technology leadership.
