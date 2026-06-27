# UC-02 – Wyświetlenie szczegółów produktu

## Opis

Użytkownik otwiera stronę szczegółów wybranego produktu. System prezentuje rozszerzone informacje, takie jak opis, cena, promocja i dostępność.

---

## Aktor

- Klient (użytkownik końcowy)

---

## Cel

Wyświetlenie pełnych informacji o pojedynczym produkcie.

---

## Scenariusz główny

1. Użytkownik wybiera produkt z katalogu
2. Aplikacja wysyła żądanie `GET /api/products/{id}`
3. System pobiera dane produktu z ProductCatalog
4. System oblicza cenę dla użytkownika (promocje)
5. System zwraca szczegóły produktu
6. Aplikacja wyświetla stronę produktu

---

## Uwagi

- Szczegóły mogą zawierać dodatkowe pola niewidoczne na liście katalogu
- Cena końcowa może różnić się od ceny bazowej w katalogu
