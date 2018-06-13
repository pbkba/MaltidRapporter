import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { CookieService } from 'angular2-cookie/core';

@Component({
    selector: 'categories',
    templateUrl: './categories.component.html',
    providers: [ CookieService ]
})

export class CategoriesComponent {
    public portionstyper: Portionstyp[];
    public kategorier: string[];
    public selectedCategory: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private cookieService: CookieService) {
        http.get(baseUrl + 'api/MaltidPortionstyp').subscribe(result => {
            this.portionstyper = result.json() as Portionstyp[];
            this.kategorier = this.portionstyper.reduce(
                function (acc: string[], cur: Portionstyp) {
                    if (acc.indexOf(cur.kategori) < 0) {
                        acc.push(cur.kategori);
                    }
                    return acc;
                },
                []);
        }, error => console.error(error));
    }

    ngOnInit(): void {
        this.selectedCategory = this.cookieService.get("KBA-MALTID-KATEGORI");
    }

    public getType(pid: string): Portionstyp|undefined {
        return this.portionstyper.find(function (p: Portionstyp) { return p.portionstyp_ID == pid });
    }

    public getTypes(category: string): Portionstyp[] {
        var result: Portionstyp[] = [];
        if (this.portionstyper) {
            result = this.portionstyper.reduce(
                function (acc: Portionstyp[], cur: Portionstyp) {
                    if (cur.kategori == category) {
                        acc.push(cur);
                    }
                    return acc;
                }, []);
        }
        return result;
    }

    public updateCategory(): void {
        var expires = new Date();
        expires.setDate(expires.getDate() + 60);
        this.cookieService.put("KBA-MALTID-KATEGORI", this.selectedCategory, { "expires": expires });
    }
}

interface Portionstyp {
    portionstyp_ID: string;
    kategori: string;
    portionstyp: string;
    pris: number;
}