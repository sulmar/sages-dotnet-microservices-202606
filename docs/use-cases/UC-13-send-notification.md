# UC-13 – Wysłanie powiadomienia

## Opis

System wysyła powiadomienie o zakończeniu płatności do zewnętrznego systemu.

---

## Aktor

- System (zewnętrzny odbiorca / webhook)

---

## Cel

Poinformowanie zewnętrznego systemu o statusie płatności.

---

## Scenariusz główny

1. System odbiera zdarzenie `PaymentCompleted`
2. System przygotowuje dane powiadomienia
3. System wysyła żądanie HTTP (webhook)
4. System odbiera odpowiedź
5. System zapisuje wynik wysłania

---

## Scenariusze błędów

- Jeśli zewnętrzny system zwróci błąd lub nie odpowie, system ponawia wysyłkę zgodnie z polityką retry.
- Jeśli liczba prób zostanie wyczerpana, system zapisuje nieudane powiadomienie do dalszej analizy lub ręcznej obsługi.
- Jeśli system odbierze duplikat zdarzenia `PaymentCompleted`, nie powinien wysłać drugiego powiadomienia dla tego samego zdarzenia.
- Wysyłka webhooka powinna być idempotentna po stronie nadawcy i wspierać identyfikator idempotencji w żądaniu.

---

## Uwagi

- Komunikacja oparta o HTTP (webhook)
- Wywołanie do zewnętrznego systemu
- Możliwe retry w przypadku błędów
- System działa asynchronicznie (po zdarzeniu)
