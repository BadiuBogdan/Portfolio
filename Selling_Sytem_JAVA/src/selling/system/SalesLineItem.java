/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

/**
 *
 * @author badiu
 */
public class SalesLineItem {

    private String denumire;
    private String descriere;
    private String pretUnitar;
    private String cantitate;
    private String pret;

    public SalesLineItem(String denumire, String descriere, String pretUnitar, String cantitate, String pret) {
        this.denumire = denumire;
        this.descriere = descriere;
        this.pretUnitar = pretUnitar;
        this.cantitate = cantitate;
        this.pret = pret;
    }

    public String getDenumire() {
        return denumire;
    }

    public void setDenumire(String denumire) {
        this.denumire = denumire;
    }

    public String getDescriere() {
        return descriere;
    }

    public void setDescriere(String descriere) {
        this.descriere = descriere;
    }

    public String getPretUnitar() {
        return pretUnitar;
    }

    public void setPretUnitar(String pretUnitar) {
        this.pretUnitar = pretUnitar;
    }

    public String getCantitate() {
        return cantitate;
    }

    public void setCantitate(String cantitate) {
        this.cantitate = cantitate;
    }

    public String getPret() {
        return pret;
    }

    public void setPret(String pret) {
        this.pret = pret;
    }

}
