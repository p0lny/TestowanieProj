
# Aplikacja internetowa "Baza filmowa"

Aplikacja będzie dawać dostęp użytkownikowi do zbiorów "Bazy filmowej", aby umożliwić odnalezienie interesujących dla użytkownika tytułów. 

Użytkownicy będą podzieleni na role USER oraz ADMIN. W zależności od posiadanej roli oraz tego czy dany użytkownik jest zalogowany w aplikacji będą dostępne określone funkcjonalności:
* Użytkownik niezalogowany będzie mieć możliwość wyłącznie przeglądania oraz filtrowania filmów oraz rejestracji.
* Użytkownik zalogowany będzie mógł dodatkowo oceniać oraz komentować filmy, a także edytować własne komentarze oraz dodawać filmy do listy "Do obejrzenia" oraz "Obejrzane". Ocenione filmy będą automatycznie dodawane do listy obejrzanych
* Administrator będzie mógł dodawać, edytować oraz usuwać filmy, a także zatwierdzać i moderować komentarze użytkowników.

Dodatkowo komentarze zawierające spoilery nie będą widoczne jawnie, ale dopiero po zgodzie użytkownika na wyświetlenie komentarza ze spoilerem (spoiler-alert). Możliwe będzie wyświetlenie historii edycji komentarza.

Średnia ocena filmu będzie wyliczana automatycznie na nowo po każdej nowej ocenie od pojedynczego użytkownika. 

Nowo zarejestrowani użytkownicy będą musieli aktywować swoje konto przechodząc link e-mail wysłany na maila.

Autoryzacja odbywać się będzie z wykorzystaniem tokenów JWT (nie uwzględnionych na poniższym diagramie).


## Diagram ERD

```mermaid
erDiagram
    MOVIES ||--o{ COMMENTS : ""
    MOVIES ||--|| RATINGS : ""
    MOVIES ||--o{ USER_MOVIE_RATINGS : ""
    MOVIES }o--o{ MOVIE_GENRES : ""
    MOVIES ||--|| MOVIE_ADDING_HISTORY : ""
    MOVIES {
        bigint id
        varchar title
	timestamp duration
	date premiere_date
	varchar production_location
	varchar language
	varchar description
	tinyint age_restriction
	varchar url_poster
	varchar url_trailer
    }
    
    GENRES }o--o{ MOVIE_GENRES : ""
    GENRES {
    	bigint id
	varchar name
    }
    
    MOVIE_GENRES {
    	bigint movie_id
	bigint genre_id
    }
    
    USERS ||--o{ COMMENTS : ""
    USERS ||--o{ USER_MOVIE_RATINGS : ""
    USERS ||--|| USER_ROLES : ""
    USERS ||--o{ MOVIE_ADDING_HISTORY : ""
    USERS ||--o{ USER_REGISTRATION_TOKENS : ""
    USERS {
    	bigint id
        varchar name
        varchar email
        varchar password
	boolean activated
	varchar url_picture
    }
    
    
    USER_REGISTRATION_TOKENS{
    	bigint id
	bigint user_id
	varchar token
	datetime expiration
    }
   
    ROLES ||--o{ USER_ROLES : ""
    ROLES{
   	bigint id
	varchar name
    }
    
    USER_ROLES{
    	bigint user_id
	bigint role_id 
    }
    
    COMMENTS ||--o{ COMMENT_EDIT_HISTORY: ""
    COMMENTS {
    	bigint id
	bigint movie_id
	bigint user_id
	boolean recommends_movie
	varchar comment
	boolean spoiler_alert
	datetime posted
	boolean moderated
    }
    
   COMMENT_EDIT_HISTORY{
   	bigint comment_id
	varchar previous_comment
	datetime posted
   }
    
    USER_MOVIE_RATINGS {
    	bigint movie_id
	bigint user_id
	tinyint rating
    }
    
    RATINGS {
     	bigint movie_id
	tinyint average_rating
	bigint votes
    }
    
    MOVIE_ADDING_HISTORY{
    	bigint id
	bigint movie_id
	bigint user_id
	datetime posted
    }
    
    MOVIES }o--o{ MOVIE_WATCHED : ""    
    USERS }o--o{ MOVIE_WATCHED : ""

    MOVIE_WATCHED{
     	bigint user_id
	bigint movie_id
    }
    
    MOVIES }o--o{ MOVIE_TO_BE_WATCHED : ""    
    USERS }o--o{ MOVIE_TO_BE_WATCHED : ""
    MOVIE_TO_BE_WATCHED{
    	bigint user_id
	bigint movie_id
    }
```
## Skład zespołu i podział prac

Oliwer Kucharzyk - backend \
Rafał Bobka - frontend

## Swagger info:

Aby podejrzeć dokumentację API otwórz stronę https://editor.swagger.io/ a następnie zaimportuj plik swagger.json dostępny w repozytorium. Docelowo dokumentcja będzie dostępna na serwerze hostującym API pod odpowiednim adresem URL.
