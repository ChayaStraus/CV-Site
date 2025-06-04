# CV Site - פורטפוליו מפתחים באמצעות GitHub API

אפליקציית Web API ב-.NET Core המיועדת למפתחים המעוניינים להציג את תיק העבודות שלהם על ידי התחברות לחשבון ה-GitHub האישי שלהם. האפליקציה שואבת מידע על הפרויקטים (repositories) והפעילות שלהם ומציגה אותו בצורה נוחה. בנוסף, קיימת אפשרות לבצע חיפוש כללי במאגרי GitHub ציבוריים.

## תיאור הפרויקט:

האפליקציה מתחברת לחשבון GitHub ומציגה:

* רשימת ה-**repositories** של המשתמש.
* מידע מפורט עבור כל **repository**:
    * שפות קוד
    * תאריך Commit אחרון
    * מספר כוכבים
    * מספר Pull Requests
    * קישור לאתר (אם קיים)
* אפשרות חיפוש במאגרי GitHub ציבוריים לפי שם, שפה ושם משתמש.

האפליקציה מפותחת כ-Web API באמצעות .NET Core.

## ארגון הקוד:

הפרויקט מפוצל לשני פרויקטים:

1.  **Class Library (Service)**: מכיל את הלוגיקה של התחברות ל-גיטאב באמצעות [Octokit](https://github.com/octokit/octokit.net).
2.  **Web API**: משתמש ב-Service ומספק API עם הפונקציונליות הנדרשת.

## שימוש ב-[Octokit](https://github.com/octokit/octokit.net):

הפרויקט משתמש בספריית Octokit (.NET GitHub API Client) לתקשורת עם GitHub.

## פונקציונליות API:

* `GetPortfolio`: מחזירה רשימת רפוזיטורי מהחשבון גיטאב של המשתמש עם פרטים כמו שפות, קומיט אחרון, כוכבים, וקישור.
* `SearchRepositories`: מאפשרת לחפש מאגרים ציבוריים ב-גיטאב לפי שם, שפה ושם משתמש (פרמטרים אופציונליים).

## Caching:

מידע הפורטפוליו נשמר ב-Cache לשיפור הביצועים, מאחר והוא מתעדכן לעיתים רחוקות. ה-Cache מתנקה מעת לעת או כאשר מזוהה עדכון בפעילות המשתמש ב-GitHub.

## הרצה מקומית

כדי להריץ את הפרויקט באופן מקומי, בצע את השלבים הבאים:

1.  **שכפל את ה-repository:**
    ```bash
    git clone [https://github.com/Ayala-levi/github-portfolio-api.git](https://github.com/Ayala-levi/github-portfolio-api.git)
    cd github-portfolio-api
    ```

2.  **צור קובץ `secrets.json`:** צור קובץ חדש בשם `secrets.json` במיקום הנדרש בפרויקט שלך (בדרך כלל באותה תיקייה של קובץ ה-`.csproj` של פרויקט ה-Web API).

3.  **הוסף את פרטי הגישה ל-GitHub לקובץ `secrets.json`:** העתק את התוכן הבא לקובץ `secrets.json` והחלף את הערכים המתאימים:
    ```json
    {
      "GitHubIntegrationOptions": {
        "UserName": "שם המשתמש שלך בגיטהאב",
        "Token": "הטוקן האישי שלך מגיטהאב"
      }
    }
    ```
    **הערה**: לעולם אל תעלה את קובץ ה-`secrets.json` למאגר הגיט שלך! הוא מכיל מידע רגיש. בדרך כלל מוסיפים אותו ל-`.gitignore`.

4.  **הרצת האפליקציה:** אתה יכול להריץ את האפליקציה באמצעות פקודות ה-.NET CLI:
    ```bash
    dotnet run --project WebApi.csproj
    ```
    או באמצעות סביבת הפיתוח המשולבת שלך (כמו Visual Studio או Rider).
