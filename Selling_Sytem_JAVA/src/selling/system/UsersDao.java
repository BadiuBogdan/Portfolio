package selling.system;

import java.util.List;

/**
 *
 * @author Gabi
 */
public interface UsersDao {

    public List<Users> getAllUsers();

    public Users getUser(String username);

    public void updateUser(Users user);

    public void deleteUser(Users user);

    public void insertUser(Users user);
}
