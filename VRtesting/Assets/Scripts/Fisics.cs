using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisics : MonoBehaviour
{
    //Obteber quaternion
    public static Vector4 Quaternion(Vector3 vect, float grados)
    {
        //grados a radianes (piRad/180)=(x/grados)
        float rad = grados * (Mathf.PI / 180);
        //magnitud del vector
        float m = Mathf.Sqrt(Mathf.Pow(vect.x, 2f) + Mathf.Pow(vect.y, 2f) + Mathf.Pow(vect.z, 2f));
        //vector unitario
        Vector3 vectUni = new Vector3(vect.x / m, vect.y / m, vect.z / m);
        //Quaternion
        Vector4 quater = new Vector4(0f, 0f, 0f, 0f);
        quater.x = vectUni.x * Mathf.Sin(rad / 2);
        quater.y = vectUni.y * Mathf.Sin(rad / 2);
        quater.z = vectUni.z * Mathf.Sin(rad / 2);
        quater.w = Mathf.Cos(rad / 2);

        return quater;
    }

    //Rotar quaternion
    public static Vector3 RotateQuaternion(Vector3 vect, float grados, Vector3 objVector)
    {
        //Vector4 del objeto
        Vector4 objVector4 = new Vector4(objVector.x, objVector.y, objVector.z, 0);

        // Obtener q
        Vector4 quater = Quaternion(vect, grados);
        //Matriz de quaterniones
        Vector4[] matriz = {new Vector4(1 - 2 * Mathf.Pow(quater.y,2) - 2 * Mathf.Pow(quater.y, 2), 2 * quater.x * quater.y - 2 * quater.w * quater.z         , 2 * quater.x * quater.z + 2 * quater.w * quater.y          , 0f),
                            new Vector4(2 * quater.x * quater.y + 2 * quater.w * quater.z         , 1 - 2 * Mathf.Pow(quater.x,2) - 2 * Mathf.Pow(quater.z, 2), 2 * quater.y * quater.z - 2 * quater.w * quater.x          , 0f),
                            new Vector4(2 * quater.x * quater.z - 2 * quater.w * quater.y         , 2 * quater.y * quater.z + 2 * quater.w * quater.x         , 1 - 2 * Mathf.Pow(quater.x, 2) - 2 * Mathf.Pow(quater.y, 2), 0f),
                            new Vector4(0f                                                        , 0f                                                        , 0f                                                         , 1f)};
        Vector4 aux = new Vector4(0f, 0f, 0f, 0f);
        //Multiplicacion de matrices
        for (int i = 0; i < matriz.Length; i++)
        {
            for (int j = 0; j < matriz.Length; j++)
            {
                aux[i] += matriz[i][j] * objVector4[j];
            }
        }

        return new Vector3(aux.x, aux.y, aux.z);
    }

    //Traslacion
    //Recive el cambio de las componentes, y el vector de posicion actual
    public static Vector3 Translate(float translateX, float translateY, float translateZ, Vector3 position)
    {
        //matriz de traslacion
        Vector4[] traslationMatrix = {new Vector4(1, 0, 0, translateX),
                                      new Vector4(0, 1, 0, translateY),
                                      new Vector4(0, 0, 1, translateZ),
                                      new Vector4(0, 0, 0,     1     )};
        //Matriz de posicion actual
        Vector4 actualPosition = new Vector4(position.x, position.y, position.z, 1f);
        //Matriz de posicion final
        Vector4 finalPosition = new Vector4(0f, 0f, 0f, 0f);

        //Multiplicacion de matrices
        for (int i = 0; i < traslationMatrix.Length; i++)
        {
            float aux = traslationMatrix[i].x * actualPosition.x;
            aux += traslationMatrix[i].y * actualPosition.y;
            aux += traslationMatrix[i].z * actualPosition.z;
            aux += traslationMatrix[i].w * actualPosition.w;

            finalPosition[i] = aux;
        }

        //Regresa vector de posicion
        return new Vector3(finalPosition.x, finalPosition.y, finalPosition.z);
    }

    //Rotar en el eje x
    public static Vector3 RotateX(float grados, Vector3 position)
    {
        //Convertir grados a radianes
        float radian = (grados * Mathf.PI) / 180f;

        //Matriz de rotacion en x
        Vector4[] rotationMatrix = {new Vector4(1,      0,                   0,           0),
                                    new Vector4(0, Mathf.Cos(radian), -Mathf.Sin(radian), 0),
                                    new Vector4(0, Mathf.Sin(radian),  Mathf.Cos(radian), 0),
                                    new Vector4(0,      0,                   0,           1)};
        //Matriz de posicion actual
        Vector4 actualPosition = new Vector4(position.x, position.y, position.z, 1f);
        //Matriz de posicion final
        Vector4 finalPosition = new Vector4(0f, 0f, 0f, 0f);

        //Multiplicacion de matrices
        for (int i = 0; i < rotationMatrix.Length; i++)
        {
            float aux = rotationMatrix[i].x * actualPosition.x;
            aux += rotationMatrix[i].y * actualPosition.y;
            aux += rotationMatrix[i].z * actualPosition.z;
            aux += rotationMatrix[i].w * actualPosition.w;

            finalPosition[i] = aux;
        }

        //Regresa vector de posicion
        return new Vector3(finalPosition.x, finalPosition.y, finalPosition.z);
    }

    //Rotar en el eje y
    public static Vector3 RotateY(float grados, Vector3 position)
    {
        //Convertir grados a radianes
        float radian = (grados * Mathf.PI) / 180f;

        //Matriz de rotacion en y
        Vector4[] rotationMatrix = {new Vector4( Mathf.Cos(radian), 0, Mathf.Sin(radian), 0),
                                    new Vector4(      0,            1,         0,         0),
                                    new Vector4(-Mathf.Sin(radian), 0, Mathf.Cos(radian), 0),
                                    new Vector4(0,                  0,         0,         1)};
        //Matriz de posicion actual
        Vector4 actualPosition = new Vector4(position.x, position.y, position.z, 1f);
        //Matriz de posicion final
        Vector4 finalPosition = new Vector4(0f, 0f, 0f, 0f);

        //Multiplicacion de matrices
        for (int i = 0; i < rotationMatrix.Length; i++)
        {
            float aux = rotationMatrix[i].x * actualPosition.x;
            aux += rotationMatrix[i].y * actualPosition.y;
            aux += rotationMatrix[i].z * actualPosition.z;
            aux += rotationMatrix[i].w * actualPosition.w;

            finalPosition[i] = aux;
        }

        //Regresa vector de posicion
        return new Vector3(finalPosition.x, finalPosition.y, finalPosition.z);
    }

    //Rotar en el eje z
    public static Vector3 RotateZ(float grados, Vector3 position)
    {
        //Convertir grados a radianes
        float radian = (grados * Mathf.PI) / 180f;

        //Matriz de rotacion en Z
        Vector4[] rotationMatrix = {new Vector4( Mathf.Cos(radian), -Mathf.Sin(radian), 0, 0),
                                    new Vector4( Mathf.Sin(radian),  Mathf.Cos(radian), 0, 0),
                                    new Vector4(       0,                    0,         1, 0),
                                    new Vector4(       0,                    0,         0, 1)};
        //Matriz de posicion actual
        Vector4 actualPosition = new Vector4(position.x, position.y, position.z, 1f);
        //Matriz de posicion final
        Vector4 finalPosition = new Vector4(0f, 0f, 0f, 0f);

        //Multiplicacion de matrices
        for (int i = 0; i < rotationMatrix.Length; i++)
        {
            float aux = rotationMatrix[i].x * actualPosition.x;
            aux += rotationMatrix[i].y * actualPosition.y;
            aux += rotationMatrix[i].z * actualPosition.z;
            aux += rotationMatrix[i].w * actualPosition.w;

            finalPosition[i] = aux;
        }

        //Regresa vector de posicion
        return new Vector3(finalPosition.x, finalPosition.y, finalPosition.z);
    }

    //Regresa la distancia entre dos puntos dados
    public static float Distance(Transform transA, Transform transB)
    {
        Vector3 A = transA.position;
        Vector3 B = transB.position;

        float distanciaAB = Mathf.Sqrt(Mathf.Pow(B.x - A.x, 2) + Mathf.Pow(B.y - A.y, 2) + Mathf.Pow(B.z - A.z, 2));

        return distanciaAB;
    }
}
