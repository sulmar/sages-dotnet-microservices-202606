# UC-15 – Rezerwacja produktów

## Opis

System rezerwuje produkty w magazynie na potrzeby składanego zamówienia, aby zapobiec sprzedaży tej samej ilości innym klientom.

---

## Aktor

- System (Ordering)

---

## Cel

Zarezerwowanie wymaganej ilości produktów przed utworzeniem zamówienia.

---

## Scenariusz główny

1. System otrzymuje żądanie rezerwacji podczas składania zamówienia
2. System wysyła żądanie do Stock (gRPC)
3. Stock weryfikuje dostępność
4. Stock tworzy rezerwację
5. Stock zwraca potwierdzenie rezerwacji
6. System kontynuuje proces tworzenia zamówienia

---

## Scenariusze błędów

- Jeśli stan magazynowy zmienił się między sprawdzeniem dostępności a rezerwacją, Stock odrzuca rezerwację.
- Jeśli równoległe zamówienia próbują zarezerwować te same produkty, Stock zapisuje tylko jedną poprawną rezerwację.
- Jeśli Ordering ponowi żądanie rezerwacji, Stock powinien obsłużyć je idempotentnie na podstawie identyfikatora zamówienia lub klucza rezerwacji.
- Jeśli rezerwacja nie powiedzie się, Ordering nie tworzy zamówienia i zwraca informację o braku możliwości realizacji.

---

## Uwagi

- Rezerwacja następuje po pozytywnej weryfikacji dostępności (UC-14)
- Rezerwacja jest zwalniana przy anulowaniu zamówienia (UC-09)
- Komunikacja Ordering → Stock odbywa się przez gRPC
