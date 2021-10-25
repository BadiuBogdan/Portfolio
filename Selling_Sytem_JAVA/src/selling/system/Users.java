package selling.system;

/**
 *
 * @author Gabi
 */
public class Users {

    private int idUser;
    private String username;
    private String password;
    private String functie;

    public Users() {
    }

    public Users(int idUser, String username, String password, String functie) {
        this.idUser = idUser;
        this.username = username;
        this.password = password;
        this.functie = functie;
    }

    public int getIdUser() {
        return idUser;
    }

    public void setIdUser(int idUser) {
        this.idUser = idUser;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getFunctie() {
        return functie;
    }

    public void setFunctie(String functie) {
        this.functie = functie;
    }

}
