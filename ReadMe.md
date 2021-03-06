# サクラエディタDIFF機能連携プログラム
## 概要
本プログラムは、サクラエディタのDIFF差分表示機能で任意のDIFFソフトウェアを使う為のプログラムです。  
 一番ニーズがありそうな「WinMergeとの連携」はこちら→[サクラエディタとWinMergeを連携する - JumpNonZero](https://www.jnz-sys.net/sakuradiff "JumpNonZero")

## 言語・動作環境
- Windows10
- .NET Framework 4.7.2 (C#)

## ダウンロード
 [こちらの「SakuraDiff_v1.1.zip」からどうぞ](https://github.com/jnz-sys/SakuraDiff/releases/ "SakuraDiff_Release")

## 使い方
1. サクラエディタのインストールディレクトリ(sakura.exeと同じディレクトリ)に本プログラム(diff.exe)とdiff.iniを配置
2. diff.iniを自分の環境に合わせて編集して保存します(diff.iniについては後述)
3. サクラエディタのDIFF差分表示機能で「DIFF差分がないときにメッセージを表示」のチェックを外します(外さなくてもいいですが、結果に関わらず差分なしと表示されます)
4. サクラエディタのDIFF差分表示機能を使います

## diff.iniについて
diff.iniは、本プログラムが実行される際に都度読み込まれる設定ファイルです。
### 設定項目について
- DiffProgram
    - 文字列形式
    - 任意のソフトウェアのフルパスを記述します(例：WinMergeなど)
- WaitTime
    - 整数形式
    - サクラエディタから本プログラムが呼び出されてから、DiffProgramで指定されたソフトウェアを実行するまでの待ち時間を指定します(ミリ秒単位、1秒=1000)
    - 基本的には0でいいと思います
- WaitProcess
    - 整数形式(0か1のみ)
    - DiffProgramで指定されたソフトウェアが終了するまで、本プログラムの終了を待つかどうか(0…待たない/1…待つ)
    - サクラエディタはdiff.exeプロセスが生きている間は対象ファイルは編集ができない？ようなので、「DIFFソフトを見ながらサクラエディタで編集」がしたい場合は0に設定することをオススメします
- ExitWaitTime
    - 整数形式
    - 本プログラムがDiffProgramで指定されたソフトウェアを実行してから、本プログラムを終了するまでの待ち時間を指定します(ミリ秒単位、1秒=1000)
    - WaitProcessを0にした場合は、本項目は3000(=3秒)とかを指定することをオススメします
        - サクラエディタはdiff.exeプロセスが終了した時点でテンポラリファイルを削除する模様。その為、WaitProcessを0にした場合はDiffProgramで指定されたソフトウェアを起動後に本プログラムが即終了し、DiffProgramで指定されたソフトウェアがDIFF対象ファイルを読み込む前にサクラエディタがテンポラリファイルを削除してしまい、エラーになることがある為
- FixArg
    - 文字列形式
    - DiffProgramで指定されたソフトウェアを実行する際のオプション(引数)を指定します
        - もしFixArg=-wrとした場合、`DiffProgramで指定したパス -wr 比較ファイル① 比較ファイル②`としてDiffProgramで指定されたソフトウェアが実行されます

## 注意点
- サクラエディタのDIFF差分表示機能の画面でのオプション類(「大文字小文字の同一視」や「空白無視」等)については、基本的に無視します。指定するDIFFソフト側で設定をしてください
    - 時間があればそのうち実装したいです…
- ソースコードからコンパイルする場合、恐らく出来上がるファイルは`SakuraDiff.exe`になるかと思いますので、`diff.exe`にリネームしてお使いください
- 本プログラムはMITライセンスです
- 紹介やリンク等はご自由にどうぞ

## 製作者
はねよし - [JumpNonZero](https://www.jnz-sys.net/ "JumpNonZero")
