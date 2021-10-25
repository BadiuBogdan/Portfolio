package selling.system;

/**
 *
 * @author Gabi
 */
public class Produs {

    private int idProdus;
    private String numeProdus;
    private String codBare;
    private String descriere;
    private double adaos;
    private double pretFinal;
    private int idTip;

    public Produs() {
    }

    public Produs(int idProdus, String numeProdus, String codBare, String descriere, double adaos, double pretFinal, int idTip) {
        this.idProdus = idProdus;
        this.numeProdus = numeProdus;
        this.codBare = codBare;
        this.descriere = descriere;
        this.adaos = adaos;
        this.pretFinal = pretFinal;
        this.idTip = idTip;
    }

    public int getIdProdus() {
        return idProdus;
    }

    public void setIdProdus(int idProdus) {
        this.idProdus = idProdus;
    }

    public String getCodBare() {
        return codBare;
    }

    public void setCodBare(String codBare) {
        this.codBare = codBare;
    }

    public String getNumeProdus() {
        return numeProdus;
    }

    public void setNumeProdus(String numeProdus) {
        this.numeProdus = numeProdus;
    }

    public String getDescriere() {
        return descriere;
    }

    public void setDescriere(String descriere) {
        this.descriere = descriere;
    }

    public double getAdaos() {
        return adaos;
    }

    public void setAdaos(float adaos) {
        this.adaos = adaos;
    }

    public double getPretFinal() {
        return pretFinal;
    }

    public void setPretFinal(float pretFinal) {
        this.pretFinal = pretFinal;
    }

    public int getIdTip() {
        return idTip;
    }

    public void setIdTip(int idTip) {
        this.idTip = idTip;
    }

}
