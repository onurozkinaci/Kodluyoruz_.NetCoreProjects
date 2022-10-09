--film tablosunda film uzunluğu length sütununda gösterilmektedir. Uzunluğu ortalama film uzunluğundan fazla kaç tane film vardır?
SELECT COUNT(*) FROM film
WHERE length >
(
   SELECT AVG(length) FROM film
);

--film tablosunda en yüksek rental_rate değerine sahip kaç tane film vardır?
SELECT COUNT(*) FROM film
WHERE rental_rate =
(
   SELECT MAX(rental_rate) FROM film
);

--film tablosunda en düşük rental_rate ve en düşük replacement_cost değerlerine sahip filmleri sıralayınız;
SELECT * FROM film
WHERE (rental_rate = (SELECT MIN(rental_rate) FROM film)) AND (replacement_cost = (SELECT MIN(replacement_cost) FROM film));

--payment tablosunda en fazla sayıda alışveriş yapan müşterileri(customer) sıralayınız;
SELECT * FROM customer
WHERE customer_id = 
( 
	SELECT customer_id FROM payment
	GROUP BY customer_id
	HAVING COUNT(*) = (
		SELECT COUNT(*) FROM payment
		GROUP BY customer_id
	    ORDER BY Count(*) DESC
	    LIMIT 1
	)
);

/**En iceride verilen(LIMIT iceren) sorgu yerine 
"SELECT MAX(count) FROM (SELECT customer_id, COUNT(payment_id) count FROM payment GROUP BY customer_id) AS sq"
sorgusu da kullanilabilir. Ayni sekilde maksimum musteri sayisini dondurecektir.
*/



