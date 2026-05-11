# Billable Hours Tracker — Requirements Document

## Overview

A backend system for law firms that allows lawyers to log billable time against cases, and enables admins to manage cases and generate invoices for clients.

---

## Roles & Actors

| Role                | Description                                                                                      |
| ------------------- | ------------------------------------------------------------------------------------------------ |
| **Admin / Partner** | Senior lawyer or office manager. Creates and manages cases, assigns lawyers, generates invoices. |
| **Lawyer**          | Logs time entries against cases they are assigned to.                                            |

---

## Functional Requirements

### 1. Case Management

- **FR-01** — An Admin can create a new Case with a name, description, and client information.
- **FR-02** — An Admin can update Case details (name, description, status).
- **FR-03** — An Admin can close a Case, preventing further time entries from being logged against it.
- **FR-04** — An Admin can assign one or more Lawyers to a Case.
- **FR-05** — A Lawyer can only log time against Cases they are assigned to.
- **FR-06** — Cases have a status: `Open`, `Closed`, `Archived`.

### 2. Time Tracking

- **FR-07** — A Lawyer can create a Time Entry against an open Case they are assigned to.
- **FR-08** — A Time Entry must include:
  - Duration (in hours, e.g. `1.5`)
  - Description (what work was done)
  - Date of work
- **FR-09** — A Lawyer can edit their own Time Entry as long as it has not been invoiced.
- **FR-10** — A Lawyer can delete their own Time Entry as long as it has not been invoiced.
- **FR-11** — An Admin can view all Time Entries across all Cases and all Lawyers.

### 3. Hourly Rates

- **FR-12** — Each Lawyer has a default hourly rate stored on their profile.
- **FR-13** — The hourly rate used for billing is captured at the time the Time Entry is created, so future rate changes do not alter historical billing.

### 4. Invoice Generation

- **FR-14** — An Admin can generate an Invoice for a Case, covering all uninvoiced Time Entries.
- **FR-15** — An Invoice must include:
  - Client name
  - Case name
  - List of Time Entries (date, lawyer name, description, duration, hourly rate, line total)
  - Subtotal per lawyer
  - Grand total
- **FR-16** — Once an Invoice is generated, its Time Entries are marked as `Invoiced` and can no longer be edited or deleted.
- **FR-17** — An Invoice has a status: `Draft`, `Sent`, `Paid`.
- **FR-18** — An Admin can mark an Invoice as `Sent` or `Paid`.

### 5. Reporting & Aggregation

- **FR-19** — The system must be able to return total billed amount per Case (sum of `duration × hourlyRate` for all Time Entries).
- **FR-20** — The system must be able to return total hours logged per Lawyer across all Cases.
- **FR-21** — The system must be able to return all Time Entries for a given Case, grouped by Lawyer.

---

## Non-Functional Requirements

- **NFR-01** — The API must be RESTful.
- **NFR-02** — All endpoints must be protected by authentication; unauthenticated requests must be rejected.
- **NFR-03** — Role-based access control must be enforced (Admin vs. Lawyer permissions).
- **NFR-04** — The system must use SQLite as the database for local development.
- **NFR-05** — All database interactions must go through Entity Framework Core.
- **NFR-06** — The codebase must follow a layered architecture: Controllers → Services → Repositories → Database.

---

## Entities (Preliminary)

Based on the requirements above, the following entities are expected:

| Entity            | Purpose                                                                                                                                    |
| ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| `User`            | Represents both Admins and Lawyers. Has a role, name, email, and hourly rate.                                                              |
| `Case`            | A legal matter belonging to a client. Has a name, description, status, and client info.                                                    |
| `CaseLawyer`      | Join table — many-to-many between Cases and Lawyers (Users).                                                                               |
| `TimeEntry`       | A single logged time block. Belongs to a Case and a Lawyer. Stores duration, description, date, hourly rate snapshot, and invoiced status. |
| `Invoice`         | Generated from a Case's uninvoiced Time Entries. Stores totals and status.                                                                 |
| `InvoiceLineItem` | A snapshot of each Time Entry at the moment of invoicing.                                                                                  |

---

## Out of Scope (for now)

- Frontend / UI
- Email delivery of invoices
- Multi-currency support
- Payments integration
